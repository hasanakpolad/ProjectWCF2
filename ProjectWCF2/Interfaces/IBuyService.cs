using Data;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBuyService" in both code and config file together.
    [ServiceContract]
    public interface IBuyService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate =
            "AddSales")]
        string AddSales(BuyHistoryDto dto);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateSales")]
        string UpdateSales(BuyHistoryDto dto);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate =
            "GetSales?id={id}")]
        string GetSales(int id);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteSales")]
        string DeleteSales(BuyHistoryDto dto);
    }
}
