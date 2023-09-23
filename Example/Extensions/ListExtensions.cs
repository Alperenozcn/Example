using Example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Extensions
{
    public static class ListExtensions
    {
        //public static void AddDuplicate(this List<Skill> skills, Skill skill)
        //{
        //    skills.Add(skill);
        //    skills.Add(skill);

        //}

        public static void AddDuplicate<T>(this List<T> list, T item) where T : class
        {
            list.Add(item);
            list.Add(item);
        }
    }
}