using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public IProductItem ProductItem { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository, IProductItem productItem)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            ProductItem = productItem;
        }
    }
}
