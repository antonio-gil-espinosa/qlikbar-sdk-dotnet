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

        /// <summary>
        /// Gets the menu from the local.
        /// </summary>
        /// <returns>Category[][].</returns>
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

        /// <summary>
        /// Sends a promotion.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="live">if set to <c>true</c> send to current clients.</param>
        /// <returns>Response.</returns>
        public Response SendPromotion(string title, string content, bool live)
        {
            string response = HttpHelper.Post("local/sendpromotion",
                                              ApiKey,
                                              new Dictionary<string, string> { { "content", content }, { "title", title }, { "live", live.ToString() } });
            return JsonConvert.DeserializeObject<Response>(response);
        }

        /// <summary>
        /// Sends the promotion.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="targets">The ids of the clients.</param>
        /// <returns>Response.</returns>
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

        /// <summary>
        /// Adds points to given client.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>Response{AddPointResultSystem.String}.</returns>
        public Response<AddPointResult, string> AddPoints(int clientId, int quantity, string reason)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> {{"quantity", quantity.ToString(CultureInfo.InvariantCulture)}, {"reason", reason}};

            string response = HttpHelper.Post("client/" + clientId + "/addpoints", ApiKey, dictionary);
            return JsonConvert.DeserializeObject<Response<AddPointResult, string>>(response);
        }

        /// <summary>
        /// Consumes points of given client.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>Response{AddPointResultSystem.String}.</returns>
        public Response<AddPointResult, string> ConsumePoints(int clientId, int quantity, string reason) { return AddPoints(clientId, quantity * -1, reason); }

        /// <summary>
        /// Adds points a client given his pase berde.
        /// </summary>
        /// <param name="paseBerde">The pase berde.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>Response{AddPointResultSystem.String}.</returns>
        [Obsolete]
        public Response<AddPointResult, string> AddPointsToPaseBerde(string paseBerde, int quantity, string reason)
        {

                    return AddPoints(GetClientByPaseBerde(paseBerde).Data.Id, quantity, reason);

  
            
        }

        /// <summary>
        /// Consumes points from a client given his pase berde.
        /// </summary>
        /// <param name="paseBerde">The pase berde.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="reason">The reason.</param>
        /// <returns>Response{AddPointResultSystem.String}.</returns>
        [Obsolete]
        public Response<AddPointResult, string> ConsumePointsToPaseBerde(string paseBerde, int quantity, string reason)
        {

                    return ConsumePoints(GetClientByPaseBerde(paseBerde).Data.Id, quantity, reason);


 
        }

        /// <summary>
        /// Sets the orders for the given table.
        /// </summary>
        /// <param name="tableId">The table id.</param>
        /// <param name="orders">The orders.</param>
        /// <returns>IEnumerable{SetOrdersResult}.</returns>
        public IEnumerable<SetOrdersResult> SetOrders(int tableId, IEnumerable<SetOrderDTO> orders)
        {
            Dictionary<string, string> data = new Dictionary<string, string> {{"orders", JsonConvert.SerializeObject(orders)}};
            string response = HttpHelper.Post("table/" + tableId + "/orders", ApiKey, data);
            return JsonConvert.DeserializeObject<IEnumerable<SetOrdersResult>>(response);
        }

        /// <summary>
        /// Gets the client given his id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Response{Client}.</returns>
        public Response<Client> GetClient(int id)
        {
            string response = HttpHelper.Get("local/client/"+id, ApiKey);
            return JsonConvert.DeserializeObject<Response<Client>>(response);
        }


        /// <summary>
        /// Gets the client by his pase berde.
        /// </summary>
        /// <param name="paseBerde">The pase berde.</param>
        /// <returns>Response{Client}.</returns>
        public Response<Client> GetClientByPaseBerde(string paseBerde)
        {

            string response = HttpHelper.Get("local/client?paseBerde="+paseBerde, ApiKey);
            return JsonConvert.DeserializeObject<Response<Client>>(response);
        }



        /// <summary>
        /// Gets the clients of the locla.
        /// </summary>
        /// <returns>Response{Client[]}.</returns>
        public Response<Client[]> GetClients()
        {
            string response = HttpHelper.Get("local/clients", ApiKey);
            return JsonConvert.DeserializeObject<Response<Client[]>>(response);
        }

        /// <summary>
        /// Gets the tables of the local.
        /// </summary>
        /// <returns>Table[][].</returns>
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

        /// <summary>
        /// Creates a table.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="name">The name.</param>
        /// <param name="remoteId">The remote id.</param>
        /// <returns>Response{CreateTableResult}.</returns>
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

        /// <summary>
        /// Edits a table.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="name">The name.</param>
        /// <param name="remoteId">The remote id.</param>
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






        /// <summary>
        /// Registers a client.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="paseBerde">The pase berde.</param>
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

        /// <summary>
        /// Deletes a table.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteTable(int id) { HttpHelper.Post("table/" + id + "/delete", ApiKey); }

        /// <summary>
        /// Opens a table.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Response.</returns>
        public Response OpenTable(int id) { return JsonConvert.DeserializeObject<Response>(HttpHelper.Post("table/" + id + "/open", ApiKey)); }

        /// <summary>
        /// Closes a table.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Response.</returns>
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

        /// <summary>
        /// Creates an article.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="image">The image.</param>
        /// <param name="price">The price.</param>
        /// <param name="categoryId">The category id.</param>
        /// <param name="visibility">The visibility.</param>
        /// <param name="remoteId">The remote id.</param>
        /// <param name="discount">The discount.</param>
        /// <param name="allowHomeOrders">if set to <c>true</c> [allow home orders].</param>
        /// <returns>Response{CreateArticleResult}.</returns>
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

        /// <summary>
        /// Edits an article.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="image">The image.</param>
        /// <param name="price">The price.</param>
        /// <param name="visibility">The visibility.</param>
        /// <param name="remoteId">The remote id.</param>
        /// <param name="discount">The discount.</param>
        /// <param name="allowHomeOrders">if set to <c>true</c> [allow home orders].</param>
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

        /// <summary>
        /// Deletes an article.
        /// </summary>
        /// <param name="id">The id.</param>
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

        /// <summary>
        /// Edits a category.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="image">The image.</param>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        /// <param name="remoteId">The remote id.</param>
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

        /// <summary>
        /// Deletes a category.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteCategory(int id) { HttpHelper.Post("category/" + id + "/delete", ApiKey); }
    }
}