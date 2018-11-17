using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support
{

    public interface IParameterNoBL
    {
        ParameterNoModel Save(ParameterNoModel parametereNo);

        void Delete(string id);

        ParameterNoModel GetData(string id);

        IEnumerable<ParameterNoModel> ListData();

        ParameterNoModel TryValidate(ParameterNoModel parametereNo);
    }

    public class ParameterNoBL : IParameterNoBL
    {
        private IParameterNoDal _parameterNoDal;

        public ParameterNoBL()
        {
            _parameterNoDal = new ParameterNoDal();
        }

        public ParameterNoBL(IParameterNoDal injParameterNoDal)
        {
            _parameterNoDal = injParameterNoDal;
        }

        public ParameterNoModel Save(ParameterNoModel parameterNo)
        {
            //  validasi
            var result = parameterNo;
            result = TryValidate(parameterNo);

            //  save
            var dummyParameterNo = _parameterNoDal.GetData(parameterNo.Prefix);
            if (dummyParameterNo == null)
            {
                _parameterNoDal.Insert(result);
            }
            else
            {
                _parameterNoDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _parameterNoDal.Delete(id);
        }

        public ParameterNoModel GetData(string id)
        {
            return _parameterNoDal.GetData(id);
        }

        public IEnumerable<ParameterNoModel> ListData()
        {
            return _parameterNoDal.ListData();
        }

        public ParameterNoModel TryValidate(ParameterNoModel parameterNo)
        {
            var result = parameterNo;

            if (parameterNo == null)
            {
                throw new ArgumentNullException(nameof(parameterNo));
            }

            if (parameterNo.Prefix.Trim() == "")
            {
                throw new ArgumentException("Prefix empty");
            }
            if (parameterNo.Value == 0)
            {
                throw new ArgumentException("Value empty");
            }

            return result;
        }
    }
}
