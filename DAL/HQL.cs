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
        public IList GetInfo(int cid)
        {
            Session = GetSession();
            return Session.CreateQuery("from info c where c.cid=:fn ")
                   .SetInt32("fn", cid)
                   .List();
        }
        //查询详细信息
        public IList GetDetail(int id)
        {
            Session = GetSession();
            return Session.CreateQuery("from info c where c.id=:fn ")
                   .SetInt32("fn",id)
                   .List();
        }
        //查询类型详细信息
        public IList GetLeveBy(int cid)
        {
            Session = GetSession();
            return Session.CreateQuery("from leve c where c.id=:fn ")
                   .SetInt32("fn",cid)
                   .List();
        }
        
        //查询所有在树中显示
        public IList GetLeve()
        {

            Session = GetSession();
            return Session.CreateQuery("from leve")
                .List();
        }
        //添加内容
        public void InfoAdd(info Info)
        {
            Session = GetSession();
            Session.Save(Info);
            Session.Flush();
        }
        //修改内容
        public void InfoUpd(info Info)
        {
            Session = GetSession();
            Session.Update(Info);
            Session.Flush();
        }
        //删除内容
        public void InfoDel(info Info)
        {
            Session = GetSession();
            Session.Delete(Info);
            Session.Flush();
        }
        //添加类型
        public void LeveAdd(leve Leve)
        {
            Session = GetSession();
            Session.Save(Leve);
            Session.Flush();
        }
        //修改类型
        public void LeveUpd(leve Leve)
        {
            Session = GetSession();
            Session.Update(Leve);
            Session.Flush();
        }
        //删除类型
        public void LeveDel(leve Leve)
        {
            Session = GetSession();
            Session.Delete(Leve);
            Session.Flush();
        }

    }
}
