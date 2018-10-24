using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Messages;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        
        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof (string),(int) HttpStatusCode.OK)]
        public void Post([FromBody] string message)
        {
        using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
            
                    bus.Publish(new TextMessage
                        {
                            Text = message
                        });
                }
        }

        
    }
}
