using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using QlikBar.SDK.DTOs;
using QlikBar.SDK.Results;

namespace QlikBar.SDK
{
    public class ClientWebServices
    {
        public int Id { get; private set; }
        public string Password { get; private set; }

        public ClientWebServices(int id,string password)
        {
            Id = id;
            Password = password;
        }

        /// <summary>
        /// Perform a checkin in the given table.
        /// </summary>
        /// <param name="idTable">The table id.</param>
        /// <returns>MobileResponse{CheckInResult}.</returns>
        public MobileResponse<CheckInResult> TableCheckIn(int idTable)
        {
            Dictionary<string, string> data = new Dictionary<string, string> { { "idMesa", idTable.ToString(CultureInfo.InvariantCulture) } };
            string response = HttpHelper.Post("client/checkin", Id, Password, data);
            MobileResponse<IEnumerable<CheckInResult>> tableCheckIn = JsonConvert.DeserializeObject <MobileResponse<IEnumerable<CheckInResult>>>(response);
            return new MobileResponse<CheckInResult>()
                   {
                       Data = new List<CheckInResult>(tableCheckIn.Data)[0],
                       Success = tableCheckIn.Success
                   };
        }



    }
}
