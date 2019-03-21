using AnugerahWinform.StokBarang.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.Presenter
{
    public class RepackPresenter
    {
        private IRepackView _view;

        public RepackPresenter(IRepackView view)
        {
            _view = view;
        }


    }
}
