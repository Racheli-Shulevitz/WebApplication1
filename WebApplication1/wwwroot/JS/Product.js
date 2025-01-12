const GetDataFromForm = () => {
    document.getElementById("PoductList").innerHTML = "";
    const nameSearch = document.querySelector("#nameSearch").value
    const minPrice = document.querySelector("#minPrice").value
    const maxPrice = document.querySelector("#maxPrice").value
    let categoryIds = JSON.parse(sessionStorage.getItem("categoryIds"))
    return ({ nameSearch, minPrice, maxPrice, categoryIds })
}
const categoryIds = []

const AddToBag = (product) => {
    let products = JSON.parse(sessionStorage.getItem("shoppingBag"))
    products.push(product)
    sessionStorage.setItem("shoppingBag", JSON.stringify(products))
    document.querySelector("#ItemsCountText").textContent = parseInt(document.querySelector("#ItemsCountText").textContent) + 1
}

const viewProducts = async (product) => {
    const template = document.getElementById("temp-card")
    let cloneProduct = template.content.cloneNode(true)
    cloneProduct.querySelector("img").src = `../Images/${product.image}`
    cloneProduct.querySelector("h1").textContent = product.productName
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector(".bag").addEventListener('click', () => { AddToBag(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const load = addEventListener("load", async () => {
    let categoryIdArr =[]
    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
    let Bag = JSON.parse(sessionStorage.getItem("shoppingBag")) || []
    sessionStorage.setItem("shoppingBag", JSON.stringify(Bag))
    filterProducts()
    getCategories()
});


const forProducts = async (products) => {
    for (let i = 0; i < products.length; i++) {
        viewProducts(products[i])
    }
};
const filterProducts = async () => {
    const { nameSearch, minPrice, maxPrice, categoryIds } = GetDataFromForm();
    let url = "api/product/"
    if (nameSearch || minPrice || maxPrice || categoryIds)
        url += '?'
    if (nameSearch != '')
        url += `&desc=${nameSearch}`
    if (minPrice)
        url += `&minPrice=${minPrice}`
    if (maxPrice)
        url += `&maxPrice=${maxPrice}`
    if (categoryIds != []) {
        for (i = 0; i < categoryIds.length; i++)
            url += `&categoryIds=${categoryIds[i]}`
    }
       
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
        if (responseGet.status == 200) {
            const products = await responseGet.json();
            console.log(products);
            forProducts(products);
        }
        else {

            alert("error")
        }
    }
     catch {
        alert("No Content");
    }
    
}


const filterCategories = async (category) => {
    let categoryIds = JSON.parse(sessionStorage.getItem("categoryIds"))
    let ind = categoryIds.indexOf(category.categoryId)
    ind == -1 ? categoryIds.push(category.categoryId) : categoryIds.splice(ind, 1)
    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIds))
    filterProducts()
}

const viewCategories = async (category) => {
    let tempCategory = document.getElementById("temp-category");
        let clonecategory = tempCategory.content.cloneNode(true);
    clonecategory.querySelector(".OptionName").innerText = category.categoryName;
    clonecategory.querySelector(".opt").addEventListener('change', () => { filterCategories(category) })

        document.getElementById("categoryList").appendChild(clonecategory)
}
const forCategories = async (categories) => {
    for (let i = 0; i < categories.length; i++) {
        viewCategories(categories[i])
    }
};

const getCategories = async () => {
    try {
        const responseGet = await fetch('/api/category', {
            method: 'Get',
            headers: {

                'Content-Type': 'application/json'
            },
        });
        if (responseGet.status == 200) {
            const categories = await responseGet.json();
            console.log(categories);
            forCategories(categories);
        }
        else {

            alert("error")
        }
    }
    catch {
        alert("No Content");
    }

}
