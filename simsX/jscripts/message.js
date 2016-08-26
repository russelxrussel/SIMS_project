function message(x, actionType){ 
  //$('#xMessage').slideToggle(300).delay(3500).slideToggle(100);

  $.blockUI({
      message: $('#xMessage')
  });

//  setTimeout($.unblockUI, 2000);
  
 

  var i = document.getElementById('imgIcon');
  var getDIV = document.getElementById('xMessage');
  
  
  //ADD
  if(actionType == 1){
   i.src = "images/messageIcon/success1.png";
   getDIV.style.background = '#003300';
   //getDIV.style.background = '#58ACFA';
  }
  //EDIT
  else if(actionType == 2){
   i.src = "images/messageIcon/success.png";
   getDIV.style.background = '#084B8A';
  }
  //REQUIRED
  else if(actionType == 3)
  {
   i.src = "images/messageIcon/stop.png";
   getDIV.style.background = '#FF0000';
  }
 
  
  
  document.getElementById("lblMessage").innerHTML = x;


//Close the dialog box
  $('#OK').click(function () {
      //      $.unblockUI();
      //      return false;
      release();
  });

}

function release() {
    $.unblockUI();
    return false;
}

function dialogMessage(xMsg) {

    $.blockUI({
        message: $('#xMessageDialog')
    });

    document.getElementById("lblMessage").innerHTML = xMsg;
}


function displayError(str) {
    //$.growlUI('Error Found', 'Ok ang', 2000);

    $.blockUI({
        //                            message: str,
        //                            timeout: 2000
        //        //message: $('#test') + '===' + str;
        //              overlayCSS: { backgroundColor: '#f00' }
        message: '<p>' + str + '</p>',
        timeout: 3000
    });

    //     setTimeout($.unblockUI, 2000);

    //alert("Error");
}