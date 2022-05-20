<template>
<div>
<div class="profilecard">
  <div :data="userInfo" class="profile block"> <!-- PROFILE (MIDDLE-CONTAINER) -->
					<el-popover
					placement="bottom"
					title="修改个人信息"
					width="400"
					trigger="click">
					<UpdateUser/>
					<el-button slot="reference" icon="el-icon-edit" circle></el-button>
  					</el-popover>
                    <div class="profile-picture big-profile-picture clear">
						<Uploader/>
                    </div>
                    <h1 class="user-name">管理员ID</h1>
					<br>
					<br>
                </div>  
</div>
</div>
</template> 
<script>
import Uploader from '../components/uploader.vue'
import UpdateUser from '../components/updateUser.vue'

export default {
    components: {
        Uploader,
        UpdateUser,
    },
    data () {
	  return {
        userInfo: {
          name: '杨初德',
		  gender: '女',
		  title: '住院医师',
		  department:'血液内科',
		  m_age:'9',
		  hospital:'上海第九人民医院',
          intro: '中国抗癌协会第四届血液肿瘤专业委员会淋系肿瘤学组副组长，中国免疫学会血液免疫专业委员会副主任委员，中国医师协会血液科医师分会副会长，中国医师协会整合医学医师分会整合血液病学专业委会第一届副主任委员等。'
		},
        }
    }
}
</script>

<style lang="scss" scoped>
/*总体CSS*/
.calendar-day {
				height: 300px;
        margin-bottom: 10px;
				background: #f2f6f8;
}
.calendar-day .titular{
  background: #056ed6;
  color: #ffffff;
}
.add-event.button{
    background: #056ed6;
    color: #ffffff;
}
.main-container {
	font-family: 'Ubuntu', sans-serif;
	margin: 0em auto;
  padding-left: 50px;
  height: 100%;
}
.el-main {
    background-color: #E9EEF3;
    color: #333;
    text-align: center;
    padding-left: 70px!important;
  }
  .avatar-uploader{
    position: relative;
    right: 12px;
    bottom: 16px;
  }
  	.block {
			margin-bottom: 10px;
			background: #ffffff;
			border-radius: 2px;
      box-shadow: 2px 5px 5px;
		}
    div.info{
      margin: 0 20px;
    }
	
    .info{
      margin: 0 30px;
      font-size:small;
    }
.profile-picture {
	border-radius: 100%;
	overflow: hidden;
	-webkit-box-sizing: content-box;
  	-moz-box-sizing: content-box;
  	box-sizing: content-box;	
}
	.big-profile-picture {
		margin: 0 auto;		
		border: 5px solid #40a0ff60;
		width: 150px;
		height: 150px;
	}
	.small-profile-picture {
		border: 2px solid #50597b;
		width: 40px;
		height: 40px;
	}
    		.profile-menu {
			float: right;
			height: 80px;
			padding-right: 20px;
		}
			.profile-menu p {
				font-size: 17px;
				display: inline-block;
				line-height: 76px;
				margin: 0;
				padding-right: 10px;
			}
				.profile-menu a {
					padding-left: 5px;
				}
					.profile-menu a:hover {
						text-decoration: none;
					}
			.small-profile-picture {
				display: inline-block;
				vertical-align: middle;				
			}
            .profile {
			}
            .add-button .icon {
					float: right;
					line-height: 18px;
					width: 23px;					
					border: 2px solid;
					border-radius: 100%;
					font-size: 18px;
					text-align: center;
					margin: 10px;					
				}
					.add-button .icon:hover {
						color: #e64c65;
						border-color: #e64c65;
					}
				.user-name {
					margin: 25px 0px 16px;
					text-align: center;
                    font-size: medium;
				}
            .profile-description {
					width: 210px;
					margin: 0 auto;
					text-align: center;
				}
				.profile-options {
					padding-top: 35px;
				}
					.profile-options li {
						border-left: 1px solid #1f253d;
					}
						.profile-options p {
							margin: 0;
						}
						.profile-options a {
							display: block;					
							width: 99px;
							line-height: 60px;
							text-align: center;
							-webkit-transition: background .3s;
							transition: background .3s;				
						}
							.profile-options a:hover {
								text-decoration: none;
								background: #50597b;
							}
							.profile-options a:hover.comments .icon {
								color: #fcb150;
							}
							.profile-options a:hover.views .icon {
								color: #11a8ab;
							}
							.profile-options a:hover.likes .icon {
								color: #e64c65;
							}
							.profile-options .icon {
								padding-right: 10px;
							}
							.profile-options .comments {
								border-top: 4px solid #fcb150;
							}
							.profile-options .views {
								border-top: 4px solid #11a8ab;
							}
							.profile-options .likes {
								border-top: 4px solid #e64c65;
							}
                            .el-button {
						position: relative;
						left: 85%;
					}
</style>
