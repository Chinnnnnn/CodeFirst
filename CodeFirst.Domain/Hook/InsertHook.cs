using EFHooks;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeFirst.Domain.Hook
{
    public class InsertHook : PreInsertHook<IHookBase>
    {
        private Token _token { get; set; }

        public InsertHook()
        {
            this._token = new Authorization().Get();
        }

        public override void Hook(IHookBase entity, HookEntityMetadata metadata)
        {
            var userId = "Unknown";
            if (this._token != null)
            {
                userId = _token.UserId;
            }

            entity.CreateUser = userId;
            entity.CreateTime = DateTime.Now;
        }

        public override bool RequiresValidation
        {
            get { return false; }
        }
    }
}
