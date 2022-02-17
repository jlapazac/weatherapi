using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace weatherapi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWeatherService" in both code and config file together.
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "weather?cuidad={cuidad}&telefono={telefono}", ResponseFormat = WebMessageFormat.Json)]
        string ObtenerBodega(string cuidad, string telefono);
    }
}
