using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Handlers;
using Newtonsoft.Json;
using Canteen.Models;
using System.Web.Http.Results;

namespace Canteen.Controllers
{
    [RoutePrefix("api/dishes")]
    public class DishesController : ApiController
    {
        #region Get All Dishes
        [HttpGet]
        [Route("GetAllDishes")]
        public object GetAllDishes()
        {
            ///Get All Dishes
            DbContext db = new DbContext("CanteenBook");
            var collection = db.LoadRecords<DishesInfo>("Canteen");
            return Json(collection);
        }
        #endregion

        #region Get dish by id
        [HttpGet]
        [Route("GetDishesById")]
        public object GetDishesById(string id)
        {
            try
            {
                DbContext db = new DbContext("CanteenBook");
                var collection = db.LoadRecordById<DishesInfo>("Canteen", new Guid(id));
                return Json(collection);
            }
            catch (Exception ex)
            {
                return new Status
                { Result = "Error", Message = ex.Message.ToString() };
            }
        }
        #endregion

        #region Delete Dishes
        [HttpGet]
        [Route("DeleteDishes")]
        public object DeleteDishes(string id)
        {
            try
            {
                DbContext db = new DbContext("CanteenBook");
                var collection = db.LoadRecordById<DishesInfo>("Canteen", new Guid(id));
                db.DeleteRecord<DishesInfo>("Canteen", collection.Id);
                return new Status
                { Result = "Sucess", Message = "Item Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new Status
                { Result = "Error", Message = ex.Message.ToString() };
            }
        }
        #endregion

        #region Insert Dishes
        [Route("InsertDishes")]
        [HttpPost]
        public Object InsertDishes(DishesInfo objDishes)
        {
            try
            {
                /// Insert Dishes
                DbContext db = new DbContext("CanteenBook");
                db.InsertRecord("Canteen", objDishes);
                return new Status
                { Result = "Sucess", Message = "Inserted Successfully" };
            }
            catch (Exception ex)
            {
                return new Status
                { Result = "Sucess", Message = ex.Message.ToString() };
            }
        }
        #endregion

        #region Deactivate dish 
        [HttpGet]
        [Route("Deactivatedishes")]
        public object DeactivateDishes(string id)
        {
            try
            {
                DbContext db = new DbContext("CanteenBook");
                var collection = db.LoadRecordById<DishesInfo>("Canteen", new Guid(id));
                collection.IsActive = false;
                db.UpsertRecord("Canteen", new Guid(id), collection);
                return new Status
                { Result = "Sucess", Message = "Sold out" };
            }
            catch (Exception ex)
            {
                return new Status
                { Result = "Error", Message = ex.Message.ToString() };
            }
        }
        #endregion

        #region Calculate Waiting time

        [HttpGet]
        [Route("CalWaitTime")]
        public object CalWaitTime(string id)
        {
            try
            {
                DbContext db = new DbContext("CanteenBook");
                var collection = db.LoadRecordById<DishesInfo>("Canteen", new Guid(id));
                return new Status
                { Result = "Sucess", Message = "Plese Wait for " + collection.PreparationTime };
            }
            catch (Exception ex)
            {
                return new Status
                { Result = "Error", Message = ex.Message.ToString() };
            }
        }
        #endregion
    }


}

