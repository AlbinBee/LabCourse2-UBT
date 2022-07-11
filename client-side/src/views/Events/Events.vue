<template>
 	<div>
		<input type="text" v-model="search" placeholder="Search events" />
		<div class="card" v-for="cinema in filter" :key="cinema.id">
			<v-card class="mx-auto my-12" max-width="374">
				<template slot="progress">
					<v-progress-linear
						color="deep-purple"
						height="10"
						indeterminate
					></v-progress-linear>
				</template>

				<v-img height="250" src="@/assets/joker.jpg"></v-img>

				<v-card-title>{{ cinema.name }}</v-card-title>

				<p class="ml-5">
					{{ cinema.city }}
				</p>

				<v-divider class="mx-4"></v-divider>

				<!-- <v-card-title>Tonight's availability</v-card-title> -->

				<v-card-actions>
					<v-btn color="deep-purple lighten-2" text :to="{ name: 'Cineplexx' }">
						View Movies
					</v-btn>
					<v-btn
						color="deep-purple lighten-2"
						text
						:to="{ name: 'CineplexxPrice' }"
					>
						See Prices
					</v-btn>
					<v-btn
						color="deep-purple lighten-2"
						text
						:to="{ name: 'CineplexxInfo' }"
					>
						Info
					</v-btn>
				</v-card-actions>
			</v-card>
		</div>
	</div>
</template>

<script>
export default {
  name: "events",

  // computed: {
  //   events() {
  //     return this.$store.state.events.events;
  //   },
  // },

  // data() {
  //   return {
  //   };
  // },

  // methods: {
  //   divOnClick() {
  //     this.$router.push({ name: "Event" });
  //   },
  //   getEvents(selectedCinema) {
  //     console.log("Test");
  //     this.$store.dispatch("getEvents", selectedCinema.id).catch((error) => {
  //       this.errorToast(
  //         error.response?.data?.errors[0] ||
  //           "Something went wrong while fetching movies!"
  //       );
  //     });
  //   },
  // },
  created() {
		this.getEvents();
	},
	computed: {
		events() {
			return this.$store.state.events.events;
		},
		filter() {
			return this.events.filter((temp) => {
				return temp.name.match(this.search);
			});
		},
	},
	methods: {
		getEvents() {
			this.$store.dispatch("getCinemas").catch((error) => {
				this.errorToast(
					error.response?.data?.errors[0] ||
						"Something went wrong while fetching cinemas!"
				);
			});
		},
	},
};
</script>

<style lang="scss" scoped>

.card {
	flex-direction: row;
	justify-content: center;
}
input {
	border: 1px solid black;
	padding: 20px;
	margin-top: 2%;
	margin-bottom: 2%;
	border-radius: 15px;
}
.container {
  width: 80%;
  margin-right: 10%;
  margin-left: 10%;
  padding: 0;
  height: auto;
  .landing {
    padding: 20px;
    display: block;
    display: flex;
    flex-direction: column;

    h3 {
      text-align: center;
      font-size: 32px;
      font-family: "Rubik", sans-serif;
    }

    p {
      text-align: center;
      font-size: 20px;
      font-family: "Poppins", sans-serif;
    }
  }

  .events {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    margin-top: 3%;
    margin-bottom: 3%;
    margin-left: 0%;
    margin-right: 0%;
    width: 100%;
    height: auto;
    justify-content: space-between;

    @media (max-width: 900px) {
      flex-direction: column;
    }

    .item {
      border: 3px solid black;
      width: 45%;
      height: 500px;
      margin-bottom: 50px;
      padding: 10px;
      border-radius: 20px;

      @media (max-width: 900px) {
        width: 100%;
      }
      .ispaid {
        @media (max-width: 900px) {
          text-align: center;
          flex-direction: column;
        }

        p {
          font-size: 28px;
          padding: 10px;
          height: 20%;
          width: 50%;
        }

        display: flex;
        flex-direction: row;
        width: 100%;
      }

      img {
        height: 80%;
        width: 100%;
      }
      @media (max-width: 900px) {
        img {
          height: 60%;
        }

        .ispaid {
          width: 80%;
          margin-right: 10%;
          margin-left: 10%;

          p {
            text-align: center;
            margin-right: 25%;
            margin-left: 25%;
          }
        }
      }
    }
  }
}
</style>
