﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Conversion.aspx.cs" Inherits="GroupDocs.Total.WebForms.Conversion" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
     <meta charset="utf-8" />
    <title>Conversion for .NET MVC</title>
    <link type="text/css" rel="stylesheet" href="/resources/common/css/all.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/v4-shims.min.css">
    <link rel="stylesheet" type="text/css" href="/resources/conversion/css/tooltipster.bundle.min.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/swiper.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/circle-progress.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer-dark.css" />
	<link type="text/css" rel="stylesheet" href="/resources/conversion/css/conversion.css" />
    <link type="text/css" rel="stylesheet" href="/resources/conversion/css/conversion.mobile.css" />
    <script type="text/javascript" src="/resources/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="/resources/conversion/js/tooltipster.bundle.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/es6-promise.auto.js"></script>
    <script type="text/javascript" src="/resources/common/js/swiper.min.js"></script>
    <script type="text/javascript" src="/resources/viewer/js/viewer.js"></script>
	<script type="text/javascript" src="/resources/conversion/js/conversion.js"></script>
</head>
<body>
    <div id="element"></div>    
     <script type="text/javascript">       
        $('#element').conversion({
            applicationPath: 'http://<%=config.Server.HostAddress%>:<%=config.Server.HttpPort%>/conversion',           
            download: <%=config.Common.download.ToString().ToLowerInvariant()%>,
            upload: <%=config.Common.upload.ToString().ToLowerInvariant()%>,           
            browse: <%=config.Common.browse.ToString().ToLowerInvariant()%>,
            rewrite: <%=config.Common.rewrite.ToString().ToLowerInvariant()%>,            
            enableRightClick: <%=config.Common.enableRightClick.ToString().ToLowerInvariant()%>
        });        
    </script>
</body>
</html>