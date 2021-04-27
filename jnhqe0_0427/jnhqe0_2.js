//a)
db.artists.insert({
    "name": "The Butterfield Blues Band",
    "country": "USA"
})

db.artists.insertMany(
    [
        {
            "name": "The Doors",
            "country": "USA"
        },
        {
            "name": "Black Sabbath",
            "country": "UK"
        },
        {
            "name": "Iron Butterfly",
            "country": "USA"
        },
        {
            "name": "Iron Maiden",
            "country": "UK"
        },
        {
            "name": "Soul Media",
            "country": "Japan"
        }
    ]
)

//b)
db.system.js.save(
    {
        _id: "hozzaRendel",
        value: function () {
            db.artists.find().forEach(function (x) {
                db.albums.updateMany({ artist: x.name }, {
                    $unset: { country: "" },
                    $set: { artist: x._id }
                }
                )
            });
        }
    }
)
db.loadServerScripts()
hozzaRendel()


//c)
db.system.js.save(
    {
        _id: "akciozas",
        value: function (genre, percentage) {
            var query = db.albums.find({ "genre": genre });
            while (query.hasNext()) {
                var album = query.next();
                album.price = album.price * (1 - percentage / 100);
                db.akcio.insert(album);
            }
        }
    }
)
db.loadServerScripts()
akciozas("Rock", 20)


//d)
db.system.js.save(
    {
        _id: "atlagar",
        value: function () {
            var atlag = db.albums.aggregate([
                { $group: { _id: "null", aprice: { $avg: "$price" } } }
            ])._batch[0].aprice;

            var query = db.albums.find({ price: { $gt: atlag } });

            while (query.hasNext()) {
                print(query.next())
            }
        }
    }
)
db.loadServerScripts()
atlagar()


//e)
db.albums.aggregate(
    [
        {
            $group: { _id: "$genre", "avgPrice(HUF)": { $avg: { $multiply: ["$price", 300] } } }
        }
    ]
)

db.albums.aggregate(
    [
        {
            $match: { price: { $gt: 20 } }
        },
        {
            $group: { _id: "$genre", count: { $sum: 1 } }
        },
        {
            $sort: { "count": -1 }
        }
    ]
)

db.albums.aggregate([
    {
        $sort: { price: 1 }
    },
    {
        $limit: 1
    },
    {
        $lookup:
        {
            from: "artists",
            localField: "artist",
            foreignField: "_id",
            as: "artist"
        }
    }
])

db.artists.aggregate([
    {
        $lookup:
        {
            from: "albums",
            localField: "_id",
            foreignField: "artist",
            as: "albums"
        }
    },
    {
        $project: {
            _id: 0,
            name: 1,
            albums: {
                title: 1
            },
            cheapestPrice: { $min: "$albums.price" },
            numberOfTitles: { $size: "$albums" }
        }
    },
    {
        $sort: { numberOfTitles: -1 }
    },
    {
        $limit: 1
    }
])
