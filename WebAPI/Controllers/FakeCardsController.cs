using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeCardsController : ControllerBase
    {
        IFakeCardService _fakeCardService;

        public FakeCardsController(IFakeCardService fakeCardService)
        {
            _fakeCardService = fakeCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(FakeCard fakeCard)
        {
            var result = _fakeCardService.Add(fakeCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(FakeCard fakeCard)
        {
            var result = _fakeCardService.Delete(fakeCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(FakeCard fakeCard)
        {
            var result = _fakeCardService.Update(fakeCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fakeCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _fakeCardService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycardnumber")]
        public IActionResult GetByCardNumber(string cardNumber)
        {
            var result = _fakeCardService.GetByCardNumber(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("iscardexist")]
        public IActionResult IsCardExist(FakeCard fakeCard)
        {
            var result = _fakeCardService.IsCardExist(fakeCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
