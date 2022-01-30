let mainDiv = document.getElementById("main");
let input = document.getElementsByClassName('input');
let photosDiv = document.getElementById("photos");


fetch(`api/rover`)
    .then(res => res.json())
    .then(data => {
        console.log(data)
        ShowRovers(data)
        /*ShowRoverPhotos(data, input)*/
    });

ShowRovers = (rovers) => {
    for (i = 0; i < rovers.length; i++) {
        mainDiv.insertAdjacentHTML('beforeend',
            `<div class="col-sm-4 position-relative text-center text-white">
                    <input type="image" src="${rovers[i].nasaURL}" style="height:100%;" class="img-thumbnail input" value="${rovers[i].name}"/>
                    <div class="centered rounded">${rovers[i].name}</div>
            </div>`
        )
        ShowRoverByName(rovers[i])
    } 
}

ShowRoverByName = (rover) =>
{
    fetch(`api/rover/${rover.name}`)
        .then(res => res.json())
        .then(data =>
        {
            console.log(data)

            for (i = 0; i < input.length; i++) {
                if (input[i].value === rover.name) {
                    input[i].addEventListener("click", () => {
                        
                        fetch(`https://api.nasa.gov/mars-photos/api/v1/rovers/${rover.name}/photos?sol=1000&api_key=rc3VYJg29wZqzRFKNYV4nFOBbHjT8Be1Afo13KCK`)
                            .then(res => res.json())
                            .then(photo => {
                                console.log(photo)
                                for (i = 0; i < 25; i++) {
                                    let photosList = `
                                        <div class="card" style="width: 18rem;">
                                            <img src="${photo.photos[i].img_src}" class="card-img-top" alt="..." style="height:100%;">
                                            <div class="card-body">
                                                <h5 class="card-title">${rover.name}</h5>
                                                <p class="card-text">Earth Date : ${photo.photos[i].earth_date}</p>
                                            </div>
                                        </div>`;
                                    photosDiv.insertAdjacentHTML('beforeend', photosList);
                                }
                            });
                    })
                }
            }
        })
}







