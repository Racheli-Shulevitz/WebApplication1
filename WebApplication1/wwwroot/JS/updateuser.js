const GetDataFromFormU = () => {
    const Email = document.querySelector("#emailU").value
    const FirstName = document.querySelector("#firstNameU").value
    const LastName = document.querySelector("#lastnameU").value
    const Password = document.querySelector("#password").value
    return ({ Email, FirstName, LastName, Password })
}
const Update = async() => {
    const currentUser = GetDataFromFormU();
    if (currentUser.FirstName.length > 15 || currentUser.LastName.length > 15)
        return alert("name must be up to 15 letters")
    if (!currentUser.Email || !currentUser.Password)
        return alert("email and password are required fields")
    try {
        const Id = sessionStorage.getItem("currentUser");
        const responsePut = await fetch(`api/user/${Id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(currentUser)
        });
        const dataPost = await responsePut
        alert(`updated`)
    }
    catch(err){
       console.log(err)
    }
    //
}