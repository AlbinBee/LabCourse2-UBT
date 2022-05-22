const ReviewModel = require("../Models/ReviewModel");

export default {
	list: async (req, res) => {
		const list = await ReviewModel.find();

		return res.json(list);
	},
	get: async (req, res) => {
		const id = req.params.id;

		const foundItem = await ReviewModel.findOne({ _id: id });
		return res.json(foundItem);
	},
	post: async (req, res) => {
		const post = req.body;

		const addReview = await new ReviewModel(post);

		addReview.save();

		return res.json(addReview);
	},
	delete: async (req, res) => {
		const { id } = req.params;

		try {
			await ReviewModel.deleteOne({
				_id: id,
				// userId: req.authId
			});
			return res.json({ deleted: true });
		} catch (err) {
			console.log(`Errori1 ${err}`);
		}
	},
	put: async (req, res) => {
		const post = req.body;

		const updatePost = await ReviewModel.updateOne({ _id: post._id }, post);

		return res.json(updatePost);
	},
};
