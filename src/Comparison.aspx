﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comparison.aspx.cs" Inherits="GroupDocs.Total.WebForms.Comparison" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <title>Comparison for .NET Web Forms</title>
  <link type="text/css" rel="stylesheet" href="/resources/comparison/css/all.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/swiper.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/circle-progress.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer-dark.css" />
    <link type="text/css" rel="stylesheet" href="/resources/comparison/css/comparison.css" />
    <link type="text/css" rel="stylesheet" href="/resources/comparison/css/comparison.mobile.css" />
    <script type="text/javascript" src="/resources/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/swiper.min.js"></script>
    <script type="text/javascript" src="resources/common/js/es6-promise.auto.js"></script>
    <script type="text/javascript" src="/resources/comparison/js/comparison.js"></script>
</head>
<body>
    <div id="element"></div>
    <script type="text/javascript">
        $('#element').comparison({
            applicationPath: 'http://<%=config.Server.HostAddress%>:<%=config.Server.HttpPort%>/comparison/',
            download: <%=config.Common.isDownload.ToString().ToLowerInvariant()%>,
            upload: <%=config.Common.isUpload.ToString().ToLowerInvariant()%>,
            print: <%=config.Common.isPrint.ToString().ToLowerInvariant()%>,
            rewrite: <%=config.Common.isRewrite.ToString().ToLowerInvariant()%>,
            preloadResultPageCount: 2,
            multiComparing: <%=config.Comparison.isMultiComparing.ToString().ToLowerInvariant()%>,
        });
    </script>
</body>
</html>

