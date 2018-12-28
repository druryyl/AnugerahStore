using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{

    public interface IPricingBL
    {
        //PriceTagDetailModel Save(string brgID, IEnumerable<PriceTagDetailModel> listPricing);

        //void Delete(string brgID);

        //PriceTagDetailModel GetData(string brgID, int qty);

        //IEnumerable<PriceTagDetailModel> ListData(string brgID);

        //PriceTagDetailModel TryValidate(PriceTagDetailModel pricing);
    }


    public class PricingBL : IPricingBL
    {
        //private IPricingDal _pricingDal;

        //public PricingBL()
        //{
        //    _pricingDal = new PricingDal();
        //}

        //public PricingBL(IPricingDal injPricingDal)
        //{
        //    _pricingDal = injPricingDal;
        //}

        //public PriceTagDetailModel Save(PriceTagDetailModel pricing)
        //{
        //    //  validasi
        //    var result = pricing;
        //    result = TryValidate(pricing);

        //    //  save
        //    var dummyPricing = _pricingDal.GetData(pricing.BrgID);
        //    if (dummyPricing == null)
        //    {
        //        _pricingDal.Insert(result);
        //    }
        //    else
        //    {
        //        _pricingDal.Update(result);
        //    }

        //    return result;
        //}

        //public void Delete(string id)
        //{
        //    _pricingDal.Delete(id);
        //}

        //public PriceTagDetailModel GetData(string id)
        //{
        //    return _pricingDal.GetData(id);
        //}

        //public IEnumerable<PriceTagDetailModel> ListData()
        //{
        //    return _pricingDal.ListData();
        //}

        //public PriceTagDetailModel TryValidate(PriceTagDetailModel pricing)
        //{
        //    var result = pricing;

        //    if (pricing == null)
        //    {
        //        throw new ArgumentNullException(nameof(pricing));
        //    }

        //    if (pricing.BrgID.Trim() == "")
        //    {
        //        throw new ArgumentException("BrgID empty");
        //    }
        //    if (pricing.Price.Trim() == "")
        //    {
        //        throw new ArgumentException("Price empty");
        //    }

        //    return result;
        //}
    }
}
