//a)
db.albums.insert({
    "title": "East-West",
    "artist": "The Butterfield Blues Band",
    "country": "USA",
    "year": 1966,
    "genre": "Blues",
    "style": [
        "Chicago Blues",
        "Soul",
        "Acid Rock"
    ],
    "price": 15
})

db.albums.insertMany([
    {
        "title": "L.A. Woman",
        "artist": "The Doors",
        "country": "USA",
        "year": 1971,
        "genre": "Rock",
        "style": ["Blues Rock", "Classic Rock"],
        "price": 20
    },
    {
        "title": "Vol. 4",
        "artist": "Black Sabbath",
        "country": "UK",
        "year": 1972,
        "genre": "Rock",
        "style": ["Hard Rock", "Heavy Metal"],
        "price": 23
    },
    {
        "title": "Sabotage",
        "artist": "Black Sabbath",
        "country": "UK",
        "year": 1975,
        "genre": "Rock",
        "style": ["Hard Rock", "Heavy Metal"],
        "price": 18
    },
    {
        "title": "In-A-Gadda-Da-Vida",
        "artist": "Iron Butterfly",
        "country": "USA",
        "year": 1968,
        "genre": "Rock",
        "style": ["Psychedelic Rock", "Experimental", "Classic Rock"],
        "price": 21
    },
    {
        "title": "The Number Of The Beast",
        "artist": "Iron Maiden",
        "country": "UK",
        "year": 1982,
        "genre": "Rock",
        "style": [
            "Heavy Metal"
        ],
        "price": 21
    },
    {
        "title": "Funky Stuff",
        "artist": "Soul Media",
        "country": "Japan",
        "year": 1975,
        "genre": "Jazz",
        "style": [
            "Jazz-Funk",
            "Fusion"
        ],
        "price": 22
    }
]
)


//b) 
db.albums.find({ year: { $gt: 1971 } }, { title: 1, year: 1, _id: 0 })

db.albums.find({ price: { $lt: 21 }, country: "UK" }, { title: 1, price: 1, _id: 0 })
db.albums.find({ $where: function () { return this.price < 21 && this.country == "UK" } }, { title: 1, price: 1, _id: 0 })

db.albums.find().sort({ "price": 1 }).limit(1)


//c)
db.albums.update({ title: "L.A. Woman" }, { $set: { title: "L.A. Woman2" } })

db.albums.update({ title: "Sabotage" }, { $push: { style: "Doom metal" } })

db.albums.updateMany({ year: { $gte: 1970, $lte: 1979 }, genre: "Rock" }, { $mul: { price: 0.8 } })

db.albums.find().forEach(function (x) {
    db.albums.update({ _id: x._id }, { $set: { rand: Math.random() } })
})
