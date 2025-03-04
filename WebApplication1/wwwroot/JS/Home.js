
const GetDataFromForm=() => {
    const Email = document.querySelector("#email").value
    const FirstName = document.querySelector("#firstName").value
    const LastName = document.querySelector("#lastname").value
    const Password = document.querySelector("#password").value
    return ({ Email, FirstName, LastName, Password })
}
const SighnIn = async () => {
    const newUser = GetDataFromForm();
    if (newUser.FirstName.length > 15 || newUser.LastName.length > 15)
       return alert("name must be up to 15 letters")
    if (!newUser.Email || !newUser.Password)
       return alert("email and password are required fields")//aaaa

    try {
        const responsePost = await fetch('api/user', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });
        const dataPost = await responsePost.json();
        if (!responsePost.ok)
            return alert("Password is week, Please enter different password")
       else
        alert(`${dataPost.firstName} created. Now login`)
    }
    catch {
        alert("No Content")
        if (!responsePost.ok)
        throw new Error(`HTTP error status${responsePost.status}`)
    }
}

const CheckPassword = async () => {
    const checkPassword = document.querySelector("#password").value
    try {
        const responsePost = await fetch(`api/user/Password/?Password=${checkPassword}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            query: { password: checkPassword }
        });
        const data = await responsePost.json();
        colorMater(data);
        if (responsePost.status === 400) 
            return alert("Password is week")
        
        else {
            return alert("Strong password")
        }
    }
    catch (err) {
        return alert(err)
    }
}

const colorMater = (data) => {
    const strengthMeter = document.getElementById("strengthMeter")
    strengthMeter.value = data;
    }

    const Visibility = () => {
        const show = document.querySelector(".login");
        show.classList.remove("login")
    }

    const GetDataFromFormLogin = () => {
        const Email = document.querySelector("#emailLogin").value
        const Password = document.querySelector("#passwordLogin").value
        return ({ Email, Password })
    }

    const Login = async () => {
        const currentUser = GetDataFromFormLogin();
        if (!currentUser.Email || !currentUser.Password)
            return alert("email and password are required fields")
        try {
            const responsePost = await fetch(`api/user/Login/?Email=${currentUser.Email}&Password=${currentUser.Password}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                query: { email: currentUser.email, password: currentUser.password }
            });
            if (responsePost.status === 204)
                return alert("user not found")

            const dataPost = await responsePost.json();
            alert(`welcome ${dataPost.lastName}!`)
            sessionStorage.setItem("currentUser", dataPost.id)
            window.location.href = "Products.html"
        }
        catch {
            alert("No Content");
            /*if (!responsePost.ok)*/
            // throw new Error(`HTTP error status${responsePost.status}`)
        }
    }
