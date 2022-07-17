<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <v-text-field
      v-model="name"
      :counter="10"
      :rules="nameRules"
      label="Name"
      required
    ></v-text-field>

    <v-text-field
      v-model="email"
      :rules="emailRules"
      label="E-mail"
      required
    ></v-text-field>
    <label for="v-rating">Rating</label>
    <v-rating
      :value="0"
      style="margin-top: 10px; margin-bottom: 30px"
      color="amber"
      dense
      half-increments
    ></v-rating>

    <v-btn :disabled="!valid" color="success" class="mr-4" @click="validate">
      Post Review
    </v-btn>

    <v-btn color="error" class="mr-4" @click="reset"> Reset Form </v-btn>
  </v-form>
</template>

<script>
export default {
  data: () => ({
    valid: true,
    name: "",
    nameRules: [
      (v) => !!v || "Name is required",
      (v) => (v && v.length <= 10) || "Name must be less than 10 characters",
    ],
    email: "",
    emailRules: [
      (v) => !!v || "E-mail is required",
      (v) => /.+@.+\..+/.test(v) || "E-mail must be valid",
    ],
    reviewTitle: "",
    reviewDescription: "",
    userId: "",
  }),

  methods: {
    validate() {
      this.$refs.form.validate();
    },
    reset() {
      this.$refs.form.reset();
    },
  },
  computed: {
    user() {
      return this.$store.state.users.user;
    },
  },
};
</script>

<style>
</style>