using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;

namespace Api.DTO.Mapping
{
    public class MappingTool
    {
        public MappingTool() { }

        public E AutomaticMapper<T, E>(T contextMapper)
        {
            E mapperResult = (E)Activator.CreateInstance(typeof(E));

            if (contextMapper == null)
                return mapperResult;

            PropertyInfo[] properties = contextMapper.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                try
                {

                    if (mapperResult.GetType().GetProperty(prop.Name) == null)
                        continue;

                    mapperResult.GetType().GetProperty(prop.Name).SetValue(mapperResult, prop.GetValue(contextMapper));
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }

            return mapperResult;
        }

        public List<E> AutomaticMapper<T, E>(IEnumerable<T> contextMapperList)
        {
            List<E> mapperResult = new List<E>();

            if (contextMapperList == null)
                return mapperResult;

            PropertyInfo[] properties =  Activator.CreateInstance<T>().GetType().GetProperties();
            
            foreach (T iten in contextMapperList)
            {
                try
                {
                    E obj = Activator.CreateInstance<E>();

                    foreach (PropertyInfo prop in properties)
                    {
                        if (obj.GetType().GetProperty(prop.Name) == null)
                            continue;

                        obj.GetType().GetProperty(prop.Name).SetValue(obj, prop.GetValue(iten));
                    }

                    mapperResult.Add(obj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            return mapperResult;
        }
    }
}
