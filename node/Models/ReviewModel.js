const mongoose = require("mongoose");

const schema = mongoose.Schema({
	reviews: String,
	film: String,
	client: String,
});

const model = mongoose.model("reviews", schema);

export default model;
