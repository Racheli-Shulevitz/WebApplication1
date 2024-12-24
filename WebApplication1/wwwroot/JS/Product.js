const GetDataFromForm = () => {
    const nameSearch = document.querySelector("#nameSearch").value
    const minPrice = document.querySelector("#minPrice").value
    const maxPrice = document.querySelector("#maxPrice").value
    return ({ nameSearch, minPrice, maxPrice })
}

const filterProducts = async () => {
    const categoryIds = []
    const { nameSearch, minPrice, maxPrice } = GetDataFromForm();
    let url = "api/product/"
    if (nameSearch || minPrice || maxPrice)
        url += '?'
    if (nameSearch != '')
        url += `&desc=${nameSearch}`
    if (minPrice)
        url += `&minPrice=${minPrice}`
    if (maxPrice)
        url += `&maxPrice=${maxPrice}`
    if (categoryIds != '')
        url += `&categoryIds=${categoryIds}`
    //    return alert("email and password are required fields")
    try {
        const responseGet = await fetch(url, {
            method: 'Get',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                desc: nameSearch,
                minPrice: minPrice,
                maxPrice: maxPrice,
                categoryIds: categoryIds
            }
        });
        if (responseGet.status==200) {
            const products = await responseGet.json();
            for (let i = 1; i < products; i++) {
                viewProducts(Products[i])
            }
        }
        else {
            
            alert("error")
        }
        //const dataPost = await responsePost.json();
        //alert(`welcome ${dataPost.lastName}!`)
        //sessionStorage.setItem("currentUser", dataPost.id)
        //window.location.href = "updateUser.html"
    }
    catch {
        alert("No Content");
    }
    const viewProducts = async(product) => {
        const template = document.getElementById("temp-card")
        let cloneProduct = template.content.cloneNode(true)
        cloneProduct.querySelector(".img-w").src ="../Images/"+product.image
        cloneProduct.querySelector("h1").textContent = product.productName
        cloneProduct.querySelector(".price").innerText = product.price
        cloneProduct.querySelector(".description").innerText = product.description
        document.getElementById("PoductList").appendChild(cloneProduct)
    }
}