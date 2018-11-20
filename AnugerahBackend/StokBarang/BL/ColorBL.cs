using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{

    public interface IColorBL
    {
        ColorModel Save(ColorModel color);

        void Delete(string id);

        ColorModel GetData(string id);

        IEnumerable<ColorModel> ListData();

        ColorModel TryValidate(ColorModel color);
    }


    public class ColorBL : IColorBL
    {
        private IColorDal _colorDal;

        public ColorBL()
        {
            _colorDal = new ColorDal();
        }

        public ColorBL(IColorDal injColorDal)
        {
            _colorDal = injColorDal;
        }

        public ColorModel Save(ColorModel color)
        {
            //  validasi
            var result = color;
            result = TryValidate(color);

            //  save
            var dummyColor = _colorDal.GetData(color.ColorID);
            if (dummyColor == null)
            {
                _colorDal.Insert(result);
            }
            else
            {
                _colorDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _colorDal.Delete(id);
        }

        public ColorModel GetData(string id)
        {
            return _colorDal.GetData(id);
        }

        public IEnumerable<ColorModel> ListData()
        {
            return _colorDal.ListData();
        }

        public ColorModel TryValidate(ColorModel color)
        {
            var result = color;

            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            if (color.ColorID.Trim() == "")
            {
                throw new ArgumentException("ColorID empty");
            }
            if (color.ColorName.Trim() == "")
            {
                throw new ArgumentException("ColorName empty");
            }

            return result;
        }
    }
}
