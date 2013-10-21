using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using QlikBar.SDK.DTOs;
using QlikBar.SDK.Results;

namespace QlikBar.SDK
{
    public class LocalWebServices
    {
        public LocalWebServices(int id, string apiKey)
        {
            ApiKey = apiKey;
            Id = id;
        }

        public int Id { get; private set; }
        public string ApiKey { get; private set; }

        public Category [] GetMenu()
        {
            string response = HttpHelper.Get("local/" + Id + "/menu", ApiKey);
            List<Category> menu = new List<Category>(JsonConvert.DeserializeObject<IEnumerable<Category>>(response));
            foreach (Category category in Enumerable.TransverseCategories(menu))
            {
                foreach (Category subcategory in category.Subcategories)
                    subcategory.Parent = category.Id;

                foreach (Article article in category.Articles)
                    article.Parent = category.Id;
            }

            return menu.ToArray();
        }

        public Response SendPromotion(string title, string content, bool live)
        {
            string response = HttpHelper.Post("local/sendpromotion",
                                              ApiKey,
                                              new Dictionary<string, string> { { "content", content }, { "title", title }, { "live", live.ToString() } });
            return JsonConvert.DeserializeObject<Response>(response);
        }

        public Response SendPromotion(string title, string content, int[] targets)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
                                                    {
                                                         {"content", content},
                                                        {"title", title},
                                                        {
                                                            "targets",
                                                            string.Join(",", Utilities.ToStringArray(targets))
                                                        },
                                                        {"live", "false"}
                                                    };
            string response = HttpHelper.Post("local/sendpromotion", ApiKey, dictionary);
            return JsonConvert.DeserializeObject<Response>(response);
        }

        public Response<AddPointResult, string> AddPoints(int clientId, int quantity, string reason)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"quantity", quantity.ToString(CultureInfo.InvariantCulture)}, {"reason", reason}};

            string response = HttpHelper.Post("client/" + clientId + "/addpoints", ApiKey, dictionary);
            return JsonConvert.DeserializeObject<Response<AddPointResult, string>>(response);
        }

        public Response<AddPointResult, string> ConsumePoints(int clientId, int quantity, string reason) { return AddPoints(clientId, quantity * -1, reason); }

        [Obsolete]
        public Response<AddPointResult, string> AddPointsToPaseBerde(string paseBerde, int quantity, string reason)
        {

                    return AddPoints(GetClientByPaseBerde(paseBerde).Data.Id, quantity, reason);

  
            
        }

        [Obsolete]
        public Response<AddPointResult, string> ConsumePointsToPaseBerde(string paseBerde, int quantity, string reason)
        {

                    return ConsumePoints(GetClientByPaseBerde(paseBerde).Data.Id, quantity, reason);


 
        }

        public IEnumerable<SetOrdersResult> SetOrders(int tableId, IEnumerable<SetOrderDTO> orders)
        {
            Dictionary<string, string> data = new Dictionary<string, string> {{"orders", JsonConvert.SerializeObject(orders)}};
            string response = HttpHelper.Post("table/" + tableId + "/orders", ApiKey, data);
            return JsonConvert.DeserializeObject<IEnumerable<SetOrdersResult>>(response);
        }

        public Response<Client> GetClient(int id)
        {
            string response = HttpHelper.Get("local/client/"+id, ApiKey);
            return JsonConvert.DeserializeObject<Response<Client>>(response);
        }


        public Response<Client> GetClientByPaseBerde(string paseBerde)
        {

            string response = HttpHelper.Get("local/client?paseBerde="+paseBerde, ApiKey);
            return JsonConvert.DeserializeObject<Response<Client>>(response);
        }



        public Response<Client[]> GetClients()
        {
            string response = HttpHelper.Get("local/clients", ApiKey);
            return JsonConvert.DeserializeObject<Response<Client[]>>(response);
        }

        public Table[] GetTables()
        {
            string response = HttpHelper.Get("local/" + Id + "/tables", ApiKey);
            return JsonConvert.DeserializeObject<Table[]>(response);
        }

        /*public IEnumerable<Category> GetCategories()
        {
            string response = Utilities.Post("categories", ApiKey, "loc=" + Id);
            return JsonConvert.DeserializeObject<Response<AddPointResult>>(response).Data;
        }

        public IEnumerable<Category> GetCategories(int localId)
        {
            string response = Utilities.Post("categories", ApiKey, "loc="+ localId);
            return JsonConvert.DeserializeObject<Response<AddPointResult>>(response).Data;
        }
        */

        /*public IEnumerable<Category2> GetSubcategories(int categoryId)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"cat", categoryId.ToString()}};
            string response = HttpHelper.Post("category", ApiKey, dictionary);
            IEnumerable<Category2> deserializeObject = JsonConvert.DeserializeObject<Response2<IEnumerable<Category2>>>(response)
                                                                  .Data;
            foreach (Category2 category2 in deserializeObject)
                category2.WebServices = this;

            return deserializeObject;
        }*/

        public Response<CreateTableResult> CreateTable(bool enabled, string name, string remoteId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"enabled", enabled.ToString()},
                                                  {"description", name},
                                                  {"remoteId", remoteId}
                                              };

            return JsonConvert.DeserializeObject<Response<CreateTableResult>>(HttpHelper.Post("table/create", ApiKey, data));

        }

        public void EditTable(int id, bool enabled, string name, string remoteId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"enabled", enabled.ToString()},
                                                  {"name", name},
                                                  {"remoteId", remoteId}
                                              };

            HttpHelper.Post("table/"+id+"/edit", ApiKey, data);
        }


 



        public void RegisterClient(string email, string password, string firstName,string lastName,string paseBerde)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"email", email},
                                                  {"pwd", password},
                                                  {"fname", firstName},
                                                  {"lname",  lastName},
                                                  {"paseberde", paseBerde}
                                              };
            HttpHelper.Post("client/register", ApiKey, data);

        }

        public void DeleteTable(int id) { HttpHelper.Post("table/" + id + "/delete", ApiKey); }

        public Response OpenTable(int id) { return JsonConvert.DeserializeObject<Response>(HttpHelper.Post("table/" + id + "/open", ApiKey)); }

        public Response CloseTable(int id) { return JsonConvert.DeserializeObject<Response>(HttpHelper.Post("table/" + id + "/close", ApiKey)); }

        public Response<CreateArticleResult> CreateArticle(string name,
                                                           string description,
                                                           string image,
                                                           decimal price,
                                                           int categoryId,
                                                           int visibility,
                                                           string remoteId,
                                                           decimal discount,
                                                           bool allowHomeOrders,
                                                           IEnumerable<ComboPart> combinationLists)
        {
            List<Dictionary<string,object>> comboList = new List<Dictionary<string, object>>();
            foreach (ComboPart cp in combinationLists)
            {
                List<object> subarticles = new List<object>();
                Dictionary<string, object> cpd = new Dictionary<string, object>() {{"description", cp.Name}, {"subarticles", subarticles}};
               

                foreach (Candidate candidate in cp.Candidates)
                    subarticles.Add(new Dictionary<string, object> {{"id", candidate.Article}, {"price", candidate.Price}});
            

                comboList.Add(cpd);
            }

            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"name", name},
                                                  {"description", description},
                                                  {"category", categoryId.ToString(CultureInfo.InvariantCulture)},
                                                  {"price",  Math.Round(price,2).ToString(CultureInfo.InvariantCulture)},
                                                  {
                                                      "visibility",
                                                      visibility.ToString(CultureInfo.InvariantCulture)
                                                  },
                                                  {"remoteId", remoteId},
                                                  {"discount",  Math.Round(discount,2).ToString(CultureInfo.InvariantCulture)},
                                                  {"allowHomeOrders", allowHomeOrders.ToString()},
                                                  {"combo_parts", JsonConvert.SerializeObject(comboList)}
                                              };

            return JsonConvert.DeserializeObject<Response<CreateArticleResult>>(HttpHelper.Post("article/create", ApiKey, data));
        }

        public Response<CreateArticleResult> CreateArticle(string name,
                                                 string description,
                                                 string image,
                                                 decimal price,
                                                 int categoryId,
                                                 int visibility,
                                                 string remoteId,
                                                 decimal discount,
                                                 bool allowHomeOrders)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"name", name},
                                                  {"description", description},
                                                  {"category", categoryId.ToString(CultureInfo.InvariantCulture)},
                                                  {"price",  Math.Round(price,2).ToString(CultureInfo.InvariantCulture)},
                                                  {
                                                      "visibility",
                                                      visibility.ToString(CultureInfo.InvariantCulture)
                                                  },
                                                  {"remoteId", remoteId},
                                                  {"discount",  Math.Round(discount,2).ToString(CultureInfo.InvariantCulture)},
                                                  {"allowHomeOrders", allowHomeOrders.ToString()}
                                              };

            return JsonConvert.DeserializeObject<Response<CreateArticleResult>>(HttpHelper.Post("article/create", ApiKey, data));
        }

        public void EditArticle(int id,
                                string name,
                                string description,
                                string image,
                                decimal price,
                                int visibility,
                                string remoteId,
                                decimal discount,
                                bool allowHomeOrders)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"name", name},
                                                  {"description", description},
                                                  {"price",  Math.Round(price,2).ToString(CultureInfo.InvariantCulture)},
                                                  {
                                                      "visibility",
                                                      visibility.ToString(CultureInfo.InvariantCulture)
                                                  },
                                                  {"remoteId", remoteId},
                                                  {"discount", Math.Round(discount,2).ToString(CultureInfo.InvariantCulture)},
                                                  {"allowHomeOrders", allowHomeOrders.ToString()}
                                              };

            HttpHelper.Post("article/" + id + "/edit", ApiKey, data);
        }

        public void DeleteArticle(int id) { HttpHelper.Post("article/" + id + "/delete", ApiKey); }

        public Response<CreateCategoryResult> CreateCategory(string name,
            string description,
            string image,
            bool visible, string remoteId, int? parent)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"name", name},
                                                  {"description", description},
                                                  {"image", image},
                                                  {
                                                      "visible",
                                                      visible.ToString()
                                                  },
                                                  {"parentCategory", parent != null? parent.ToString() : null},
                                                  {"remoteId", remoteId}
                                             
                                              };

            return JsonConvert.DeserializeObject<Response<CreateCategoryResult>>(HttpHelper.Post("category/create", ApiKey, data));
        }

        public void EditCategory(int id,
                                 string name,
            string description,
            string image,
            bool visible, string remoteId)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                                              {
                                                  {"name", name},
                                                  {"description", description},
                                                  {"image", image},
                                                  {
                                                      "visible",
                                                      visible.ToString()
                                                  },
                                                  {"remoteId", remoteId}
                                              };

            HttpHelper.Post("category/" + id + "/edit", ApiKey, data);
        }

        public void DeleteCategory(int id) { HttpHelper.Post("category/" + id + "/delete", ApiKey); }
    }
}