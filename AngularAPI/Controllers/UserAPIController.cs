﻿using AngularAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularAPI.Controllers
{
    public class UserAPIController : ApiController
    {
        DemoEntities objEntity = new DemoEntities();
        [HttpGet]
        [ActionName("GetUserDetails")]
        public IQueryable<userdetail> GetUser()
        {
            try
            {
                return objEntity.userdetails;
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        [ActionName("GetUserDetailsById/{userId}")]
        public IHttpActionResult GetUserById(string userId)
        {
            userdetail objUser = new userdetail();
            int ID = Convert.ToInt32(userId);
            try
            {
                objUser = objEntity.userdetails.Find(ID);
                if (objUser == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objUser);
        }

        [HttpPost]
        [ActionName("InsertUserDetails")]
        public IHttpActionResult PostUser(userdetail data)
        {
            string message = "";
            if (data != null)
            {
                try
                {
                    objEntity.userdetails.Add(data);
                    int result = objEntity.SaveChanges();
                    if (result > 0)
                    {
                        message = "User has been sussfully added";
                    }
                    else
                    {
                        message = "faild";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Ok(message);
        }

        [HttpPut]
        [ActionName("UpdateEmployeeDetails")]
       public IHttpActionResult PutUserMaster(userdetail user)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                userdetail objUser = new userdetail();
                objUser = objEntity.userdetails.Find(user.userid);
                if (objUser != null)
                {
                    objUser.username = user.username;
                    objUser.emailid = user.emailid;
                    objUser.gender = user.gender;
                    objUser.address = user.address;
                    objUser.mobileno = user.mobileno;
                    objUser.pincode = user.pincode;
                }
                int result = objEntity.SaveChanges();
                if (result > 0)
                {
                    message = "User has been sussfully updated";
                }
                else
                {
                    message = "faild";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(message);
        }

        [HttpDelete]
        [ActionName("DeleteUserDetails")]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            string message = "";
            userdetail user = objEntity.userdetails.Find(id);
            objEntity.userdetails.Remove(user);
            int result = objEntity.SaveChanges();
            if (result > 0)
            {
                message = "User has been sussfully deleted";
            }
            else
            {
                message = "faild";
            }
            return Ok(message);
        }
    }
    }
