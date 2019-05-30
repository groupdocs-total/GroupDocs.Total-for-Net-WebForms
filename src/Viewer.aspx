﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="GroupDocs.Total.WebForms.Viewer" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Viewer for .NET WebForms</title>
    <link rel="icon" type="image/x-icon" href="favicon.ico" />
    <link rel="stylesheet" type="text/css" href="resources/angular/viewer/assets/css/all.min.css" />
</head>
<body>
    <gd-viewer-angular-root></gd-viewer-angular-root>
    <script type="text/javascript" src="resources/angular/viewer/runtime.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/es2015-polyfills.js" nomodule></script>
    <script type="text/javascript" src="resources/angular/viewer/polyfills.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/styles.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/scripts.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/vendor.js"></script>
    <script type="text/javascript" src="resources/angular/viewer/main.js"></script>
</body>
</html>
