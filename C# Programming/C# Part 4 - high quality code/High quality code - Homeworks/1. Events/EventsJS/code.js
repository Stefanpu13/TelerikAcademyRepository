//global comma separated list of variables
var applicationName = navigator.appName;
var addScroll = false;
if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

var positionX = 0;
var positionY = 0;

document.onmousemove = mouseMove;
if (applicationName === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

function PopTip() {
    if (applicationName === "Netscape") {
        var theLayer = document.layers.ToolTip;
        
        if ((positionX + 120) > window.innerWidth) {
            positionX = window.innerWidth - 150;
        }
        
        theLayer.left = positionX + 10;
        theLayer.top = positionY + 15;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.ToolTip;
        
        if (theLayer) {
            positionX = event.x - 5;
            positionY = event.y;
            
            if (addScroll) {
                positionX = positionX + document.body.scrollLeft;
                positionY = positionY + document.body.scrollTop;
            }
            if ((positionX + 120) > document.body.clientWidth) {
                positionX = positionX - 150;
            }
            
            theLayer.style.pixelLeft = positionX + 10;
            theLayer.style.pixelTop = positionY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function mouseMove(event) {
    if (applicationName === "Netscape") {
        positionX = event.pageX - 5;
        positionY = event.pageY;
        
        if (document.layers.ToolTip.visibility === 'show') {
            PopTip();
        }
    } else {
        positionX = event.x - 5;
        positionY = event.y;
        
        if (document.all.ToolTip.style.visibility === 'visible') {
            PopTip();
        }
    }
}

function HideTip() {
    if (applicationName === "Netscape") {
        document.layers.ToolTip.visibility = 'hide';
    } else {
        document.all.ToolTip.style.visibility = 'hidden';
    }
}

function HideMenu1() {
    if (applicationName === "Netscape") {
        document.layers.menu1.visibility = 'hide';
    } else {
        document.all.menu1.style.visibility = 'hidden';
    }
}

function ShowMenu1() {
    if (applicationName === "Netscape") {
        var theLayer = document.layers.menu1;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.menu1;
        theLayer.style.visibility = 'visible';
    }
}

function HideMenu2() {
    if (applicationName === "Netscape") {
        document.layers.menu2.visibility = 'hide';
    } else {
        document.all.menu2.style.visibility = 'hidden';
    }
}

function ShowMenu2() {
    if (applicationName === "Netscape") {
        var theLayer = document.layers.menu2;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.menu2;
        theLayer.style.visibility = 'visible';
    }
}