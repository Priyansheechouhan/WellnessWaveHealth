var email = document.getElementById('email');

var emailvalidate = /^[A-Za-z\._\-0-9]*[@][A-Za-z]*[\.][a-z]{2,4}$/
function emailcheck() {
    document.getElementById('emailError').style.color = 'red';
    if (!email.value.match(emailvalidate)) {
        document.getElementById('emailError').innerHTML = 'please enter valid email';
        
    }
    else {
        document.getElementById('emailError').innerHTML = '';
        
    }
}

function numcheck(checking) {
    document.getElementById('num').style.color = 'red';
    if (isNaN(checking.value)) {
        document.getElementById('num').innerText = "You can only insert numbers.....";
        
    } else {
        document.getElementById('num').innerText = "";
       
        if (checking.value.length > 10) {
            document.getElementById('num').innerText = "You can only insert maximum 10 digits.....";
            
        }
        else {
            document.getElementById('num').innerText = "";
           
        }
    }

}



