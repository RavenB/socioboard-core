﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocioBoard.Domain;
using SocioBoard.Helper;

namespace SocioBoard.Model
{
    public class GooglePlusActivitiesRepository : IGooglePlusActivitiesRepository
    {
        public void addgoogleplusActivity(GooglePlusActivities gpmsg)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(gpmsg);
                        transaction.Commit();
                    }
                    catch (Exception Err)
                    {
                        Console.Write(Err.Message.ToString());
                    }
                }
            }
        }

        public int deletegoogleplusActivity(GooglePlusActivities gpmsg)
        {
            throw new NotImplementedException();
        }

        public int updategoogleplusActivity(GooglePlusActivities gpmsg)
        {
            throw new NotImplementedException();
        }

        public List<GooglePlusActivities> getAllgoogleplusActivityOfUser(Guid UserId, string profileId)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<GooglePlusActivities> alst = session.CreateQuery("from GooglePlusActivities where UserId = :userid and GpUserId = :profileId")
                        .SetParameter("userid", UserId)
                        .SetParameter("profileId", profileId)
                        .List<GooglePlusActivities>()
                        .ToList<GooglePlusActivities>();



                        #region oldcode
                        //List<GooglePlusActivities> alst = new List<GooglePlusActivities>();
                        //foreach (GooglePlusActivities item in query.Enumerable<GooglePlusActivities>().OrderByDescending(x => x.PublishedDate))
                        //{
                        //    alst.Add(item);
                        //} 
                        #endregion

                        return alst;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        return null;
                    }

                }
            }
        }


        public List<GooglePlusActivities> getAllgoogleplusActivityOfUser(string profileId)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<GooglePlusActivities> alst = session.CreateQuery("from GooglePlusActivities where  GpUserId = :profileId")

                        .SetParameter("profileId", profileId)
                        .List<GooglePlusActivities>()
                        .ToList<GooglePlusActivities>();



                        #region oldcode
                        //List<GooglePlusActivities> alst = new List<GooglePlusActivities>();
                        //foreach (GooglePlusActivities item in query.Enumerable<GooglePlusActivities>().OrderByDescending(x => x.PublishedDate))
                        //{
                        //    alst.Add(item);
                        //} 
                        #endregion

                        return alst;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        return null;
                    }

                }
            }
        }
        //public void getAllgoogleplusActivitysOfUsers(Guid UserId, string profileId)
        //{
        //    using (NHibernate.ISession session = SessionFactory.GetNewSession())
        //    {
        //        using (NHibernate.ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                NHibernate.IQuery query = session.CreateQuery("from GooglePlusActivities where UserId = :userid and GpUserId = :profileId");
        //                query.SetParameter("userid", UserId);
        //                query.SetParameter("profileId", profileId);
        //                foreach (var item in query.Enumerable())
        //                {

        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.StackTrace);

        //            }

        //        }
        //    }
        //}

        public bool checkgoogleplusActivityExists(string Id, Guid Userid)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        NHibernate.IQuery query = session.CreateQuery("from GooglePlusActivities where UserId = :userid and ActivityId = :msgid");
                        query.SetParameter("userid", Userid);
                        query.SetParameter("msgid", Id);
                        var result = query.UniqueResult();

                        if (result == null)
                            return false;
                        else
                            return true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        return true;
                    }

                }
            }
        }

        public void deleteAllActivitysOfUser(string gpuserid, Guid userid)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        NHibernate.IQuery query = session.CreateQuery("delete from GooglePlusActivities where UserId = :userid and GpUserId = :profileId");
                        query.SetParameter("userid", userid);
                        query.SetParameter("profileId", gpuserid);
                        int isUpdated = query.ExecuteUpdate();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);

                    }

                }
            }
        }

        public List<GooglePlusActivities> getgoogleplusActivity(Guid userid, string profileid)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<GooglePlusActivities> alst = session.CreateQuery("from GooglePlusActivities where UserId = :userid and GpUserId = :profileId")
                        .SetParameter("userid", userid)
                        .SetParameter("profileId", profileid)
                        .List<GooglePlusActivities>()
                        .ToList<GooglePlusActivities>();

                        #region oldcode
                        //List<GooglePlusActivities> alst = new List<GooglePlusActivities>();
                        //foreach (GooglePlusActivities item in query.Enumerable<GooglePlusActivities>().OrderByDescending(x => x.PublishedDate))
                        //{
                        //    alst.Add(item);
                        //} 
                        #endregion

                        return alst;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        return null;
                    }

                }
            }
        }
    }
}