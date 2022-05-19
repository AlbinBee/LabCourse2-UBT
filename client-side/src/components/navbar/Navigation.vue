<template>
<header>
 <nav class="container">
      <div class="branding">
        <router-link class="header">
         <p class="test">Test</p> 
        </router-link>
      </div> 
      <div class="nav-links">
        <ul>
          <router-link class="link">
            Home
          </router-link>
          <router-link class="link">
            Admin Dashboard
          </router-link>
        </ul>
      </div>
    </nav>
    <menuIcon/>
    <transition name="mobile-nave">
       <ul>
          <router-link class="link">
            Home
          </router-link>
          <router-link class="link">
            Admin Dashboard
          </router-link>
        </ul>
    </transition>
</header>
</template>

<script>
import { signOut } from "firebase/auth";
import menuIcon from '../../assets/Icons/bars-regular.svg'
export default { 
  name:"navigation",

  components:{
    menuIcon
  },

  methods: {
    handleSignOut() {
      signOut(this.auth).then(() => {
        this.$router.push("/");
      });
    },
  },
  computed: {
    currentUser() {
      return this.auth?.currentUser;
    },
    firstName() {
      return this.currentUser.displayName;
    },
    userImg() {
      return this.currentUser.photoURL;
    },
  },
  props: {
    isLoggedIn: {
      required: true,
      type: Boolean,
    },
    auth: {
      required: true,
    },
  },
};
</script>


<style lang="scss" scoped>
header {
  padding: 0 25px;
  box-shadow: 0 4px 6px -1 rgba(0, 0, 0, 0.1),
    0 2px 4px -1px rgba(0, 0, 0, 0.86);
  border-bottom: 3px solid red;

  .link {
    font-weight: 500;
    padding: 0.8px;
    transition: 0.3s color ease;
    padding: 15px;
    border: 4px solid red;

    &:hover {
      color: teal;
    }
  }

  .header {
    font-size: 25px;
  }
}

nav {
  display: flex;
  padding: 25px 0;

  .branding {
    display: flex;
    align-items: center;

    .header {
      font-weight: 600;
      font-size: 24;
      text-decoration: none;
      color: black;
    }
  }


  .nav-links {
    position: relative;
    display: flex;
    flex: 1;
    align-items: center;
    justify-content: flex-end;

    .ul {
      margin-right: 32px;

      .link {
        margin-right: 32px;
      }

      .link:last-child {
        margin-right: 0;
      }
    }

    .profile {
      position: relative;
      cursor: pointer;
      display: flex;
      align-items: center;
      justify-content: center;
      width: 40px;
      height: 40px;
      border-radius: 50%;
      color: #fff;
      background-color: #303030;

      span {
        pointer-events: none;
      }

      .profile-menu {
        position: absolute;
        z-index: 3;
        top: 60px;
        right: 0;
        width: 250px;
        background-color: #303030;
        box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);

        .info {
          display: flex;
          align-items: center;
          padding: 50px;
          border-bottom: 1px solid #fff;

          .initials {
            position: initial;
            width: 40px;
            height: 40px;
            background-color: #fff;
            color:#303030;
            display: flex;
            align-items: center;
            display: flex;
            align-items: center;
            justify-content: center;
            border-radius: 50%;
          }

          .right {
            flex: 1;
            margin-left: 24px;

            p:nth-child(1) {
              font-size: 14px;
            }

            p:nth-child(2),
            p:nth-child(3) {
              font-size: 12px;
            }
          }
        }

        .options {
          padding: 15px;
          .option {
            text-decoration: none;
            color: #fff;
            display: flex;
            align-items: center;
            margin-bottom: 12px;

            .icon {
              width: 18px;
              height: auto;
            }
            p {
              font-size: 14px;
              margin-left: 12px;
            }

            &:last-child {
              margin-bottom: 0px;
            }
          }
        }
      }
    }
  }
}

.menu-icon {
  cursor: pointer;
  position: absolute;
  top: 32px;
  right: 25px;
  height: 25px;
  width: auto;
}

.mobile-nav {
  padding: 20px;
  width: 70%;
  max-width: 250px;
  display: flex;
  flex-direction: column;
  position: fixed;
  height: 100%;
  background-color: #303030;
  top: 0;
  left: 0;
  z-index: 3;

  .link {
    padding: 15px 0;
    color: whitesmoke;
  }
}

.mobile-nav-enter-active,
.mobile-nav-leave-active {
  transition: all 1s ease;
}

.mobile-nav-enter {
  transform: translateX(-250px);
}

.mobile-nav-enter-to {
  transform: translateX(0);
}

.mobile-nav-leave-to {
  transform: translateX(-250px);
}
</style>

