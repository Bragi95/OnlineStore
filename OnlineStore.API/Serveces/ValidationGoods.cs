using OnlineStore.Business.Models.Input;
using System.Text.RegularExpressions;

namespace OnlineStore.API.Serveces
{
    public class ValidationGoods
    {
        public string ValidateGoodsInputModel(GoodsInputModel model)
        {
            string validationResult = string.Empty;

            validationResult += model.YearOfManufacture == null ? $"{ResponseMessage.YearOfManufactureFieldMissing} \n" :
                ValidateDateFormat(model.YearOfManufacture);

            validationResult += model.Weight == null ? $"{ResponseMessage.WeightFieldMissing} \n" : $"{string.Empty}";

            validationResult += model.Brand == null ? $"{ResponseMessage.BrandFieldMissing} \n" : $"{string.Empty}";

            validationResult += model.Model == null ? $"{ResponseMessage.BrandFieldMissing} \n" : $"{string.Empty}";

            validationResult += model.Price == null ? $"{ResponseMessage.BrandFieldMissing} \n" : $"{string.Empty}";

            validationResult += model.CountryId == null ? $"{ResponseMessage.BrandFieldMissing} \n" : $"{string.Empty}";
           

            return validationResult;
        }
       

        public string ValidateDateFormat(string date)
        {
            if (!Regex.Match(date, @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d").Success)
            {
                return $"{ResponseMessage.InvalidDateFormat} \n";
            }
            return $"{string.Empty}";
        }       
    }
}
