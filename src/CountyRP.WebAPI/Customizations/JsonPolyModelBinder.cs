using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace CountyRP.WebAPI.Customizations
{
    public class JsonPolyModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            StreamReader reader = new StreamReader(bindingContext.ActionContext.HttpContext.Request.Body);
            string json = await reader.ReadToEndAsync();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var result = JsonConvert.DeserializeObject(json, bindingContext.ModelType, settings);
            bindingContext.Result = ModelBindingResult.Success(result);
        }
    }
}
