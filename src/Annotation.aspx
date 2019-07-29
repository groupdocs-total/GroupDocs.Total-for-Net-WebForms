﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Annotation.aspx.cs" Inherits="GroupDocs.Total.WebForms.Annotation" %>

<%
    GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Total.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <title>Annotation for .NET Web Forms</title>
     <link type="text/css" rel="stylesheet" href="/resources/common/css/all.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/v4-shims.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/swiper.min.css">
    <link type="text/css" rel="stylesheet" href="/resources/common/css/jquery-ui.min.css" />
    <link type="text/css" rel="stylesheet" href="/resources/common/css/circle-progress.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/viewer/css/viewer-dark.css" />
    <link type="text/css" rel="stylesheet" href="/resources/annotation/css/bcPicker.css" />
    <link type="text/css" rel="stylesheet" href="/resources/annotation/css/bcPicker.mobile.css" />
    <link type="text/css" rel="stylesheet" href="/resources/annotation/css/annotation.css" />
    <link type="text/css" rel="stylesheet" href="/resources/annotation/css/annotation.mobile.css" />
    <script type="text/javascript" src="/resources/common/js/jquery.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/swiper.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery.initialize.min.js"></script>
    <script type="text/javascript" src="/resources/common/js/jquery.timeago.js"></script>
    <script type="text/javascript" src="/resources/common/js/es6-promise.auto.js"></script>
    <script type="text/javascript" src="/resources/viewer/js/viewer.js"></script>
    <script type="text/javascript" src="/resources/annotation/js/svg.min.js"></script>
    <script type="text/javascript" src="/resources/annotation/js/svg.draw.js"></script>
    <script type="text/javascript" src="/resources/annotation/js/bcPicker.js"></script>
    <script type="text/javascript" src="/resources/annotation/js/drawSvgAnnotation.js"></script>
    <script type="text/javascript" src="/resources/annotation/js/drawTextAnnotation.js"></script>
    <script type="text/javascript" src="/resources/annotation/js/annotation.js"></script>
</head>
<body>
    <div id="element"></div>
    <script type="text/javascript">       
        $('#element').annotation({
                    applicationPath: 'http://<%=config.GetServerConfiguration().HostAddress%>:<%=config.GetServerConfiguration().HttpPort%>/annotation',
                    defaultDocument: '<%=config.GetAnnotationConfiguration().GetDefaultDocument()%>',
                    preloadPageCount: <%=config.GetAnnotationConfiguration().GetPreloadPageCount()%>,
                    pageSelector: <%=config.GetCommonConfiguration().pageSelector.ToString().ToLowerInvariant()%>,
                    download: <%=config.GetCommonConfiguration().download.ToString().ToLowerInvariant()%>,
                    upload: <%=config.GetCommonConfiguration().upload.ToString().ToLowerInvariant()%>,
                    print: <%=config.GetCommonConfiguration().print.ToString().ToLowerInvariant()%>,
                    browse: <%=config.GetCommonConfiguration().browse.ToString().ToLowerInvariant()%>,
                    rewrite: <%=config.GetCommonConfiguration().rewrite.ToString().ToLowerInvariant()%>,
                    textAnnotation: <%=config.GetAnnotationConfiguration().GetIsTextAnnotation().ToString().ToLowerInvariant()%>,
                    areaAnnotation: <%=config.GetAnnotationConfiguration().GetIsAreaAnnotation().ToString().ToLowerInvariant()%>,
                    pointAnnotation: <%=config.GetAnnotationConfiguration().GetIsPointAnnotation().ToString().ToLowerInvariant()%>,
                    textStrikeoutAnnotation: <%=config.GetAnnotationConfiguration().GetIsTextStrikeoutAnnotation().ToString().ToLowerInvariant()%>,
                    polylineAnnotation: <%=config.GetAnnotationConfiguration().GetIsPolylineAnnotation().ToString().ToLowerInvariant()%>,
                    textFieldAnnotation: <%=config.GetAnnotationConfiguration().GetIsTextFieldAnnotation().ToString().ToLowerInvariant()%>,
                    watermarkAnnotation: <%=config.GetAnnotationConfiguration().GetIsWatermarkAnnotation().ToString().ToLowerInvariant()%>,
                    textReplacementAnnotation: <%=config.GetAnnotationConfiguration().GetIsTextReplacementAnnotation().ToString().ToLowerInvariant()%>,
                    arrowAnnotation: <%=config.GetAnnotationConfiguration().GetIsArrowAnnotation().ToString().ToLowerInvariant()%>,
                    textRedactionAnnotation: <%=config.GetAnnotationConfiguration().GetIsTextRedactionAnnotation().ToString().ToLowerInvariant()%>,
                    resourcesRedactionAnnotation: <%=config.GetAnnotationConfiguration().GetIsResourcesRedactionAnnotation().ToString().ToLowerInvariant()%>,
                    textUnderlineAnnotation: <%=config.GetAnnotationConfiguration().GetIsTextUnderlineAnnotation().ToString().ToLowerInvariant()%>,
                    dGetIstanceAnnotation: <%=config.GetAnnotationConfiguration().GetIsDistanceAnnotation().ToString().ToLowerInvariant()%>,
                    downloadOriginal:  <%=config.GetAnnotationConfiguration().GetIsDownloadOriginal().ToString().ToLowerInvariant()%>,
                    downloadAnnotated:  <%=config.GetAnnotationConfiguration().GetIsDownloadAnnotated().ToString().ToLowerInvariant()%>,
                    enableRightClick: <%=config.GetCommonConfiguration().enableRightClick.ToString().ToLowerInvariant()%>,
                    zoom: <%=config.GetAnnotationConfiguration().GetIsZoom().ToString().ToLowerInvariant()%>,
                    fitWidth: <%=config.GetAnnotationConfiguration().GetIsFitWidth().ToString().ToLowerInvariant()%>
                });
    </script>
</body>
</html>