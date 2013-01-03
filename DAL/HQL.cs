using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Domain;
using System.Collections;

namespace DAL
{
    public class HQL
    {
        private ISession Session { get; set; }
        public HQL()
        {
        }
        public static ISession GetSession()
        {
            ISessionFactory _sessionfactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = _sessionfactory.OpenSession();
            return session;
        }
        //查询所有在树中显示
        public IList<info> GetLeve(int cid)
        {
            Session = GetSession();
            return Session.CreateQuery("from info c where c.cid=:fn ")
                   .SetInt32("fn", cid)
                   .List<info>();
        }

        //查询所有在树中显示
        public IList<leve> GetFrist()
        {

            Session = GetSession();
            return Session.CreateQuery("from leve").List<leve>();
        }

    }
}
