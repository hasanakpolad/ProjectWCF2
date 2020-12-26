//using Data;
using Data.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProjectWCF2.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddProduct")]
        string AddProduct(ProductDto dto);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateProduct")]
        string UpdateProduct(ProductDto dto);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProduct?id={id}")]
        string GetProduct(SearchDto search);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteProduct")]
        string DeleteProduct(ProductDto dto);
    }
}
