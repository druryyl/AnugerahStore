using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Support.BL;
using AnugerahWinform.Support.View;

namespace AnugerahWinform.Support.Presenter
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private IUserrBL _userrBL;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
            _userrBL = new UserrBL();
        }
        public void Login()
        {
            var userr = _userrBL.GetData(_view.UserrID);
            var isValidLogin = _userrBL.IsValidPassword(userr, _view.Password);
            //if(isValidLogin)
                
        }
    }
}
