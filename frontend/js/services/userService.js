const addUserButton = document.querySelector('#btnAddUser');

function addUser(name, email, password) {
    const body = {
        name: name,
        email: email,
        password: password,
        products: null,
        recipes: null
    }

    fetch('https://localhost:44357/api/users', {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
    .then(data => data.json())
    .then(response => console.log(response));
}

addUserButton.addEventListener('click', function() {
    addUser()
});