﻿<%@ Application Language="C#" %>

<script runat="server">

    protected void Application_Start() 
    {
        
        proje.Database.Configure();

    }
    protected void Application_BeginRequest()
    {
        proje.Database.OpenSession();
    }
    protected void Application_EndRequest()
    {
        proje.Database.CloseSession();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
