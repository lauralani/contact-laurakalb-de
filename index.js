$(document).ready(function () {
    $('.frame').click(function () {
        $('.top').addClass('open');
        $('.message').addClass('pull');
    })
});



async function formsubmit() {

    setformstatedisabled(true)
    setsubmitbuttondisabled(true)

    setmessage("Sending... \u23F3")

    let formcontent = {
        "name": document.getElementById("name").value,
        "email": document.getElementById("email").value,
        "phone": document.getElementById("phone").value,
        "body": btoa(document.getElementById("messarea").value)
    }

    let response = await fetch("/api/submit", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'X-Laura-Domain': window.location.hostname
        },
        body: JSON.stringify(formcontent),
        mode: "same-origin"
    })

    if (response.ok) {
        console.log("Response OK")
        setmessage("Sent! \u2713 thanks :)")
    }
    else {
        console.log("Response not OK")
        setmessage("\u274C Something went wrong :(")
    }

    console.log("Request complete! response:", response);

}



function setformstatedisabled(bool) {
    document.getElementById("name").disabled = bool;
    document.getElementById("email").disabled = bool;
    document.getElementById("phone").disabled = bool;
    document.getElementById("messarea").disabled = bool;
}

function setsubmitbuttondisabled(bool) {
    document.getElementById("send").disabled = bool;
}

function setmessage(message) {
    document.getElementById("send").value = message
}
