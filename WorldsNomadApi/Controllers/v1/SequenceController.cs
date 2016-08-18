using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WorldsNomad.Logic.Processor;
using WorldsNomad.Model.Response;

namespace WorldsNomadApi.Controllers.v1
{
    /// <summary>
    /// Sequence controller to get the different numeric sequences
    /// </summary>
    [RoutePrefix("api/v1/Sequence")]
    public class SequenceController : ApiController
    {
        /// <summary>
        /// Sequence generator logic
        /// </summary>
        protected ISequenceGenerator SequenceGenerator { get; private set; }

        /// <summary>
        /// IOC injection by constructor
        /// </summary>
        /// <param name="sequenceGenerator"></param>
        public SequenceController(ISequenceGenerator sequenceGenerator)
        {
            SequenceGenerator = sequenceGenerator;
        }

        /// <summary>
        /// S3 Results
        /// </summary>
        /// <remarks>Get all avaiable number sequences for S3 Results</remarks>
        /// <param name="input">value entered</param>
        /// <returns></returns>
        [Route("{input}"), AllowAnonymous, ResponseType(typeof(List<Response>))]
        public async Task<IHttpActionResult> GetAllSequences(int input)
        {
            try
            {
                Response[] responses =
                {
                    await SequenceGenerator.GetNumberSequence(input),
                    await SequenceGenerator.GetOddSequence(input),
                    await SequenceGenerator.GetEvenSequence(input),
                    await SequenceGenerator.GetSpeicalSequence(input),
                    await SequenceGenerator.GetFibonacciSequence(input)
                };

                return Ok<Response[]>(responses);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// S3.1.1: Number sequence
        /// </summary>
        /// <remarks>All numbers up-to and including the number entered</remarks>
        /// <param name="input">value entered</param>
        /// <returns></returns>
        [Route("number/{input}"), AllowAnonymous, ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> GetNumberSequence(int input)
        {
            try
            {
                var response = await SequenceGenerator.GetNumberSequence(input);
                return Ok<Response>(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// S3.1.2: Odd number sequence
        /// </summary>
        /// <remarks>All odd numbers up-to and including the number entered</remarks>
        /// <param name="input">value entered</param>
        /// <returns></returns>
        [Route("odd/{input}"), AllowAnonymous, ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> GetOddNumberSequence(int input)
        {
            try
            {
                var response = await SequenceGenerator.GetOddSequence(input);
                return Ok<Response>(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// S3.1.3: Even number sequence
        /// </summary>
        /// <remarks>All even numbers up-to and including the number entered</remarks>
        /// <param name="input">value entered</param>
        /// <returns></returns>
        [Route("even/{input}"), AllowAnonymous, ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> GetEvenNumberSequence(int input)
        {
            try
            {
                var response = await SequenceGenerator.GetEvenSequence(input);
                return Ok<Response>(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// S3.1.4: Special number sequence
        /// </summary>
        /// <remarks>All numbers up-to and including the number entered, except 'C' when multiple of 3, 'E' when multiple of 5 and 'Z' when multiple of both 3 and 5</remarks>
        /// <param name="input">value entered</param>
        /// <returns></returns>
        [Route("special/{input}"), AllowAnonymous, ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> GetSpecialNumberSequence(int input)
        {
            try
            {
                var response = await SequenceGenerator.GetSpeicalSequence(input);
                return Ok<Response>(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// S3.1.5: Fibonacci number sequence
        /// </summary>
        /// <remarks>All fibonacci number up-to and including the number entered</remarks>
        /// <param name="input">value entered</param>
        /// <returns></returns>
        [Route("fibonacci/{input}"), AllowAnonymous, ResponseType(typeof(Response))]
        public async Task<IHttpActionResult> GetFibonacciNumberSequence(int input)
        {
            try
            {
                var response = await SequenceGenerator.GetFibonacciSequence(input);
                return Ok<Response>(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
