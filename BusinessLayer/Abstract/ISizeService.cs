using Entities.Concrete;


namespace BusinessLayer.Abstract
{
    public interface ISizeService
	{
        List<string> GetSizesName();

        List<Size> GetAll();
    }

}
