using Data.Interfaces;
using Data.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cluster_Management_Studio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingController : ControllerBase
    {
        #region OldFunctions
        //// GET: api/<IncomingController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<IncomingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<IncomingController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<IncomingController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<IncomingController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion

        #region Functions
        #region GET

        /// <summary>
        /// Hashed Values Parameter Contains the Signed Value of the Message
        /// Header: auth-token Contains the Encrypted Value of the Message
        /// 
        /// Message: SELECT---(What to Select);;;TABLE---(Which Table to use);;;WHERE---(Where parameter for the query)
        /// </summary>
        /// <param name="Hashed_Values"></param>
        /// <returns></returns>
        // api/<IncomingController>
        [HttpGet("{Hashed_Values}")]
        public async Task<IActionResult> Get(string Hashed_Values)
        {
            Request.Headers.TryGetValue("auth-token", out var token);

            Helpers.Verifier<GetMessage, List<Tuple<string, object>>> helper = new Helpers.Verifier<GetMessage, List<Tuple<string, object>>>();
            ICluster<List<Tuple<string, object>>> cluster_manager_Service = new Cluster_Get();

            return await helper.Verify(token, cluster_manager_Service.Get, Hashed_Values, new GetMessage());
        }

        #endregion
        #region POST

        #endregion
        #region PUT

        #endregion
        #endregion
    }
}
