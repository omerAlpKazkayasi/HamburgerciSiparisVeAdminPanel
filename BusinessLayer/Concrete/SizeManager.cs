using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace BusinessLayer.Concrete
{
    public class SizeManager:ISizeService
    {
        ISizeDal _sizeDal;

        public SizeManager(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }

        public List<string> GetSizesName()
        {
           var var= _sizeDal.GetAll();
            return var.Select(x=>x.SizeName).ToList();
        }

        public List<Size> GetAll()
        {
            return _sizeDal.GetAll();
        }

        
    }
}
