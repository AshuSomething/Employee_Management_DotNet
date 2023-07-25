using CoreLogic.Models;
using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreLogic.Services
{
    public class RequestService
    {
        public List<Request> GetAllRequests()
        {
            using (MyContext ctx = new MyContext())
            {
                var requests = ctx.Requests.ToList();
                return requests;
            }
        }

        public Request GetRequestById(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                var request = ctx.Requests.Find(id);
                return request;
            }
        }

        public void AddRequest(Request request)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Requests.Add(request);
                ctx.SaveChanges();
            }
        }

        public void UpdateRequest(Request updatedRequest)
        {
            using (MyContext ctx = new MyContext())
            {
                var existingRequest = ctx.Requests.Find(updatedRequest.Id);

                if (existingRequest != null)
                {
                    // Update the properties of the existing request
                    existingRequest.Name = updatedRequest.Name;
                    existingRequest.Email = updatedRequest.Email;
                    existingRequest.Password = updatedRequest.Password;
                    existingRequest.RequestType = updatedRequest.RequestType;
                    //existingRequest.Id = updatedRequest.Id;

                    ctx.SaveChanges();
                }
            }
        }

        public void DeleteRequest(int id)
        {
            using (MyContext ctx = new MyContext())
            {
                var requestToDelete = ctx.Requests.Find(id);

                if (requestToDelete != null)
                {
                    

                    // Remove the request from Requests table
                    ctx.Requests.Remove(requestToDelete);

                    ctx.SaveChanges();
                }
            }
        }

        
    }
}
