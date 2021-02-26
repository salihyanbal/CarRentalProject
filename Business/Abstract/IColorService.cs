using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int id);


    }
}
