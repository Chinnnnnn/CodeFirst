using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;

namespace CodeFirst.Data
{
    public class RepositoryBase<TEntity> : InterfaceBase<TEntity>
        where TEntity : class
    {
        private DbContext _dbContext { get; set; }

        /// <summary>
        /// 建構EF一個Entity的Repository，需傳入此Entity的Context。
        /// </summary>
        /// <param name="dbContext">Entity所在的Context</param>
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 新增一筆資料到資料庫。
        /// </summary>
        /// <param name="entity">要新增到資料的庫的Entity</param>
        public void Create(TEntity entity)
        {
            _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            _dbContext.Set<TEntity>().Add(entity);

            try
            { 
                this.SaveChanges(); 
            }
            catch (Exception ex)
            {
 
            }
        }

        /// <summary>
        /// 取得符合條件的內容。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// 取得所有資料。
        /// </summary>
        public IQueryable<TEntity> GetAll()
        {
            _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return _dbContext.Set<TEntity>();
        }

        /// <summary>
        /// 更新一筆Entity內容。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

            try
            {
                _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Print(JsonConvert.SerializeObject(ex));
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// 更新一筆Entity的內容。只更新有指定的Property。
        /// </summary>
        /// <param name="entity">要更新的內容</param>
        /// <param name="updateProperties">需要更新的欄位。</param>
        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            _dbContext.Configuration.ValidateOnSaveEnabled = false;

            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (updateProperties != null)
            {
                foreach (var property in updateProperties)
                {
                    _dbContext.Entry<TEntity>(entity).Property(property).IsModified = true;
                    _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                    this.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的Entity</param>
        public void Delete(TEntity entity)
        {
            _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            _dbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
            this.SaveChanges();
        }

        /// <summary>
        /// 刪除多筆資料內容。
        /// </summary>
        /// <param name="predicate">刪除條件</param>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _dbContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            _dbContext.Set<TEntity>().Where(predicate).Delete();
            this.SaveChanges();
        }

        /// <summary>
        /// 儲存異動。
        /// </summary>
        public void SaveChanges()
        {
            _dbContext.SaveChanges();

            // 因為Update 單一model需要先關掉validation，因此重新打開
            if (_dbContext.Configuration.ValidateOnSaveEnabled == false)
            {
                _dbContext.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
