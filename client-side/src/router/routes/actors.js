export default [
	{
		path: "/admin/actors",
		name: "ActorsDashboard",
		meta: {
			requiresAuth: true,
			layout: "dashboard",
		},
		component: () =>
			import(
				/* webpackChunkName: "admin" */ "../../views/Admin/Actors/ActorsDashboard"
			),
	},
	{
		path: "/admin/actors/create",
		name: "actor-create",
		meta: {
			requiresAuth: true,
			layout: "dashboard",
		},
		component: () =>
			import(
				/* webpackChunkName: "admin" */ "../../views/Admin/Actors/AddActor"
			),
	},
	{
		path: "/admin/actors/edit/:actorId",
		name: "actor-edit",
		meta: {
			requiresAuth: true,
			layout: "dashboard",
		},
		component: () =>
			import(
				/* webpackChunkName: "admin" */ "../../views/Admin/Actors/EditActor"
			),
	},
	{
		path: "/admin/actors/details/:actorId",
		name: "actor-details",
		meta: {
			requiresAuth: true,
			layout: "dashboard",
		},
		component: () =>
			import(
				/* webpackChunkName: "admin" */ "../../views/Admin/Actors/ActorDetails"
			),
	},
];
