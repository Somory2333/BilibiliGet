namespace net8
{
    public enum VideoType
    {

        /// <summary>
        /// 动画主分区
        /// </summary>
        douga = 1,

        /// <summary>
        /// MAD·AMV
        /// </summary>
        anime_mad = 24,

        /// <summary>
        /// //MMD·3D
        /// </summary>
        mmd = 25,

        /// <summary>
        /// 手书
        /// </summary>
        handdrawn = 47,

        /// <summary>
        /// 配音
        /// </summary>
        voice = 257,

        /// <summary>
        /// 手办,模玩
        /// </summary>
        garage_kit = 210,

        /// <summary>
        /// 特摄
        /// </summary>
        tokusatsu = 86,

        /// <summary>
        /// 动漫杂谈
        /// </summary>
        acgntalks = 253,

        /// <summary>
        /// 综合
        /// </summary>
        other = 27,

        /// <summary>
        /// 番剧(主分区)
        /// </summary>
        anime = 13,

        /// <summary>
        /// 动画番剧相关资讯视频	
        /// </summary>
        Anime_information = 51,

        /// <summary>
        /// 动画番剧为主题的宣传节目、采访视频，及声优相关视频	
        /// </summary>
        offical = 152,

        /// <summary>
        /// 已完结的动画番剧合集	
        /// </summary>
        finish = 32,

        /// <summary>
        /// 当季连载的动画番剧	
        /// </summary>
        serial = 33,

        /// <summary>
        /// 国创(主分区)	
        /// </summary>
        guochuang = 167,

        /// <summary>
        /// 国产动画	
        /// </summary>
        chinese = 153,

        /// <summary>
        /// 国产原创相关	
        /// </summary>
        original = 168,

        /// <summary>
        /// 布袋戏
        /// </summary>
        puppetry = 169,

        /// <summary>
        /// 资讯
        /// </summary>
        Chinese_information = 170,

        /// <summary>
        /// 动态漫·广播剧	
        /// </summary>
        motioncomic = 195,

        /// <summary>
        /// 音乐(主分区)	
        /// </summary>
        music = 3,

        /// <summary>
        /// 原创歌曲及纯音乐，包括改编、重编曲及remix	
        /// </summary>
        music_original = 28,

        /// <summary>
        /// 对曲目的人声再演绎视频	
        /// </summary>
        music_cover = 31,

        /// <summary>
        /// 以VOCALOID等歌声合成引擎为基础，运用各类音源进行的创作	
        /// </summary>
        vocaloid = 30,

        /// <summary>
        /// 乐器和非传统乐器器材的演奏作品。	
        /// </summary>
        music_perform = 59,

        /// <summary>
        /// 为音乐作品配合拍摄或制作的音乐录影带（Music Video），以及自制拍摄、剪辑、翻拍MV
        /// </summary>
        music_mv = 193,

        /// <summary>
        /// 音乐表演的实况视频，包括官方/个人拍摄的综艺节目、音乐剧、音乐节、演唱会等
        /// </summary>
        music_live = 29,

        /// <summary>
        /// 所有无法被收纳到其他音乐二级分区的音乐类视频
        /// </summary>
        music_other = 130,

        /// <summary>
        /// 音乐类新闻、盘点、点评、reaction、榜单、采访、幕后故事、唱片开箱等
        /// </summary>
        music_commentary = 243,

        /// <summary>
        /// 音乐教学	
        /// </summary>
        music_tutorial = 244,

        /// <summary>
        /// 舞蹈(主分区)	
        /// </summary>
        dance = 129,

        /// <summary>
        ///宅舞 
        /// </summary>
        otaku = 20,

        /// <summary>
        /// 收录无法定义到其他舞蹈子分区的舞蹈视频	
        /// </summary>
        three_d = 154,

        /// <summary>
        /// 镜面慢速，动作分解，基础教程等具有教学意义的舞蹈视频	
        /// </summary>
        dance_demo = 156,

        /// <summary>
        /// 收录街舞相关内容，包括赛事现场、舞室作品、个人翻跳、FREESTYLE等	
        /// </summary>
        hiphop = 198,

        /// <summary>
        /// 国内外明星发布的官方舞蹈及其翻跳内容	
        /// </summary>
        star_dance = 199,

        /// <summary>
        /// 收录国风向舞蹈内容，包括中国舞、民族民间舞、汉唐舞、国风爵士等	
        /// </summary>
        china_dance = 200,

        /// <summary>
        /// 手势舞及网红流行舞蹈、短视频舞蹈等相关视频	
        /// </summary>
        gestures_dance = 255,

        /// <summary>
        /// 游戏(主分区)
        /// </summary>
        game = 4,

        /// <summary>
        /// 以所有平台（PC、主机、移动端）的单机或联机游戏为主的视频内容，包括游戏预告、CG、实况解说及相关的评测、杂谈与视频剪辑等	
        /// </summary>
        stand_alone = 17,

        /// <summary>
        /// 具有高对抗性的电子竞技游戏项目，其相关的赛事、实况、攻略、解说、短剧等视频。	
        /// </summary>
        esports = 171,

        /// <summary>
        /// 以手机及平板设备为主要平台的游戏，其相关的实况、攻略、解说、短剧、演示等视频。	
        /// </summary>
        mobile_game = 172,

        /// <summary>
        /// 由网络运营商运营的多人在线游戏，以及电子竞技的相关游戏内容。包括赛事、攻略、实况、解说等相关视频	
        /// </summary>
        online_game = 65,

        /// <summary>
        /// 桌游、棋牌、卡牌对战等及其相关电子版游戏的实况、攻略、解说、演示等视频。	
        /// </summary>
        board_game = 173,

        /// <summary>
        /// 由游戏素材制作的MV视频。以游戏内容或CG为主制作的，具有一定创作程度的MV类型的视频	
        /// </summary>
        gmv = 121,

        /// <summary>
        /// 各个平台上，通过配合音乐与节奏而进行的音乐类游戏视频	
        /// </summary>
        music_game = 136,

        /// <summary>
        /// 以Mugen引擎为平台制作、或与Mugen相关的游戏视频	
        /// </summary>
        mugen_game = 19,

        /// <summary>
        /// 知识区
        /// </summary>
        knowledge = 36,

        /// <summary>
        /// 科学科普
        /// </summary>
        science_knowledge = 201,

        /// <summary>
        /// 社科·法律·心理
        /// </summary>
        social_science = 124,

        /// <summary>
        /// 人文历史
        /// </summary>
        humanity_history = 228,

        /// <summary>
        /// 财经商业
        /// </summary>
        business = 207,

        /// <summary>
        /// 校园学习
        /// </summary>
        campus = 208,

        /// <summary>
        /// 职业职场
        /// </summary>
        career = 209,

        /// <summary>
        /// 设计·创意
        /// </summary>
        design = 229,

        /// <summary>
        /// 技能党集合，是时候展示真正的技术了
        /// </summary>
        skill = 122,

        /// <summary>
        /// 科技(主分区)
        /// </summary>
        tech = 188,

        /// <summary>
        /// 科技数码产品大全，一起来做发烧友
        /// </summary>
        digital = 95,

        /// <summary>
        /// 软件应用,超全软件应用指南	
        /// </summary>
        application = 230,

        /// <summary>
        /// 研究分析、教学演示、经验分享......有关计算机技术的都在这里
        /// </summary>
        computer_tech = 231,

        /// <summary>
        /// 科工机械,从小芯片到大工程，一起见证科工力量	
        /// </summary>
        industry = 232,

        /// <summary>
        /// 极客DIY,炫酷技能，极客文化，硬核技巧，准备好你的惊讶
        /// </summary>
        diy = 233,

        /// <summary>
        /// 运动(主分区)
        /// </summary>
        sports = 234,

        /// <summary>
        /// 与篮球相关的视频，包括但不限于篮球赛事、教学、评述、剪辑、剧情等相关内容
        /// </summary>
        basketball = 235,

        /// <summary>
        /// 与足球相关的视频，包括但不限于足球赛事、教学、评述、剪辑、剧情等相关内容
        /// </summary>
        football = 249,

        /// <summary>
        /// 与健身相关的视频，包括但不限于瑜伽、CrossFit、健美、力量举、普拉提、街健等相关内容
        /// </summary>
        aerobics = 164,

        /// <summary>
        /// 与竞技体育相关的视频，包括但不限于乒乓、羽毛球、排球、赛车等竞技项目的赛事、评述、剪辑、剧情等相关内容
        /// </summary>
        athletic = 236,

        /// <summary>
        /// 与运动文化相关的视频，包络但不限于球鞋、球衣、球星卡等运动衍生品的分享、解读，体育产业的分析、科普等相关内容
        /// </summary>
        culture = 237,


        /// <summary>
        /// 与运动综合相关的视频，包括但不限于钓鱼、骑行、滑板等日常运动分享、教学、Vlog等相关内容
        /// </summary>
        comprehensive = 238,


        /// <summary>
        /// 汽车(主分区)
        /// </summary>
        car = 223,

        /// <summary>
        /// 关于汽车技术与文化的硬核科普，以及生活中学车、用车、养车的相关知识
        /// </summary>
        car_knowledge = 258,

        /// <summary>
        /// F1等汽车运动相关
        /// </summary>
        racing = 245,

        /// <summary>
        /// 汽车文化及改装车相关内容，包括改装车、老车修复介绍、汽车聚会分享等内容
        /// </summary>
        modifiedvehicle = 246,

        /// <summary>
        /// 新能源汽车相关内容，包括电动汽车、混合动力汽车等车型种类，包含不限于新车资讯、试驾体验、专业评测、技术解读、知识科普等内容
        /// </summary>
        newenergyvehicle = 247,

        /// <summary>
        /// 房车及营地相关内容，包括不限于产品介绍、驾驶体验、房车生活和房车旅行等内容
        /// </summary>
        touringcar = 248,

        /// <summary>
        /// 摩托车
        /// </summary>
        motorcycle = 240,

        /// <summary>
        /// 丰富详实的购车建议和新车体验
        /// </summary>
        strategy = 227,

        /// <summary>
        /// 分享汽车及出行相关的生活体验类视频
        /// </summary>
        car_life = 176,

        /// <summary>
        /// 生活区
        /// </summary>
        life = 160,

        /// <summary>
        /// 各种沙雕有趣的搞笑剪辑，挑战，表演，配音等视频
        /// </summary>
        funny = 138,

        /// <summary>
        /// 为达到观光游览、休闲娱乐为目的的远途旅行、中近途户外生活、本地探店
        /// </summary>
        travel = 250,

        /// <summary>
        /// 分享美好农村生活
        /// </summary>
        rurallife = 251,

        /// <summary>
        /// 与买房、装修、居家生活相关的分享
        /// </summary>
        home = 239,

        /// <summary>
        /// 手工制品的制作过程或成品展示、教程、测评类视频
        /// </summary>
        handmake = 161,

        /// <summary>
        /// 绘画过程或绘画教程，以及绘画相关的所有视频
        /// </summary>
        painting = 162,

        /// <summary>
        /// 记录日常生活，分享生活故事
        /// </summary>
        daily = 21,

        /// <summary>
        /// 分享亲子、萌娃、母婴、育儿相关的视频
        /// </summary>
        parenting = 254,

        /// <summary>
        /// 美食(主分区)
        /// </summary>
        food = 211,

        /// <summary>
        /// 美食制作
        /// </summary>
        food_make = 76,

        /// <summary>
        /// 寻找美味餐厅，发现街头美食
        /// </summary>
        food_detective = 212,

        /// <summary>
        /// 美食测评
        /// </summary>
        measurement = 213,

        /// <summary>
        /// 田园美食
        /// </summary>
        rural = 214,

        /// <summary>
        /// 美食记录,记录一日三餐，给生活添一点幸福感
        /// </summary>
        food_record = 215,

        /// <summary>
        /// 动物圈(主分区)
        /// </summary>
        animal = 217,

        /// <summary>
        /// 喵星人
        /// </summary>
        cat = 218,

        /// <summary>
        /// 汪星人	
        /// </summary>
        dog = 219,

        /// <summary>
        /// 动物二创	,解说、配音、剪辑、混剪
        /// </summary>
        second_edition = 220,

        /// <summary>
        /// 野生动物	
        /// </summary>
        wild_animal = 221,

        /// <summary>
        /// 小宠异宠,奇妙宠物大赏	
        /// </summary>
        reptiles = 222,

        /// <summary>
        /// 动物综合	收录除上述子分区外，其余动物相关视频以及非动物主体或多个动物主体的动物相关延伸内容
        /// </summary>
        animal_composite = 75,

        /// <summary>
        /// 鬼畜(主分区)
        /// </summary>
        kichiku = 119,

        /// <summary>
        /// 鬼畜调教
        /// </summary>
        guide = 22,

        /// <summary>
        /// 音MAD使用素材音频进行一定的二次创作来达到还原原曲的非商业性质稿件
        /// </summary>
        mad = 26,

        /// <summary>
        /// 将人物或者角色的无伴奏素材进行人工调音，使其就像VOCALOID一样歌唱的技术
        /// </summary>
        manual_vocaloid = 126,

        /// <summary>
        /// 鬼畜剧场
        /// </summary>
        theatre = 216,

        /// <summary>
        /// 鬼畜相关的教程演示
        /// </summary>
        course = 127,

        /// <summary>
        /// 时尚(主分区)
        /// </summary>
        fashion = 155,

        /// <summary>
        /// 彩妆护肤、美甲美发、仿妆、医美相关内容分享或产品测评
        /// </summary>
        fashion_makeup = 157,

        /// <summary>
        /// 对二次元、三次元人物角色进行模仿、还原、展示、演绎的内容	
        /// </summary>
        cos = 252,


        /// <summary>
        /// 穿搭风格、穿搭技巧的展示分享，涵盖衣服、鞋靴、箱包配件、配饰（帽子、钟表、珠宝首饰）等	
        /// </summary>
        clothing = 158,

        /// <summary>
        /// 时尚街拍、时装周、时尚大片，时尚品牌、潮流等行业相关记录及知识科普	
        /// </summary>
        catwalk = 159,

        /// <summary>
        /// 资讯(主分区)
        /// </summary>
        information = 202,

        /// <summary>
        /// 全民关注的时政热门资讯	
        /// </summary>
        hotspot = 203,

        /// <summary>
        /// 全球范围内发生的具有重大影响力的事件动态
        /// </summary>
        global = 204,

        /// <summary>
        /// 日常生活的社会事件、社会问题、社会风貌的报道	
        /// </summary>
        social = 205,

        /// <summary>
        /// 上述领域外其它垂直领域的综合资讯
        /// </summary>
        multiple = 206,

        /// <summary>
        /// 娱乐(主分区)
        /// </summary>
        ent = 5,

        /// <summary>
        /// 所有综艺相关，全部一手掌握！
        /// </summary>
        variety = 71,

        /// <summary>
        /// 娱乐人物解读、娱乐热点点评、娱乐行业分析	
        /// </summary>
        talker = 241,

        /// <summary>
        /// 粉丝向创作视频	
        /// </summary>
        fans = 242,

        /// <summary>
        /// 娱乐圈动态、明星资讯相关	
        /// </summary>
        celebrity = 137,

        /// <summary>
        /// 影视(主分区)
        /// </summary>
        cinephile = 181,

        /// <summary>
        /// 影视评论、解说、吐槽、科普等
        /// </summary>
        cinecism = 182,

        /// <summary>
        /// 对影视素材进行剪辑再创作的视频	
        /// </summary>
        montage = 183,

        /// <summary>
        /// 小剧场 有场景、有剧情的演绎类内容	
        /// </summary>
        shortmovie = 85,

        /// <summary>
        /// 影视类相关资讯，预告，花絮等视频	
        /// </summary>
        trailer_info = 184,

        /// <summary>
        /// 各种类型的短片
        /// </summary>
        shortfilm = 256,

        /// <summary>
        /// 纪录片(主分区)
        /// </summary>
        documentary = 177,

        /// <summary>
        /// 人文·历史	
        /// </summary>
        history = 37,

        /// <summary>
        /// 科学·探索·自然	
        /// </summary>
        science = 178,

        /// <summary>
        /// 军事
        /// </summary>
        military = 179,

        /// <summary>
        /// 社会·美食·旅行	
        /// </summary>
        all_travel = 180,

        /// <summary>
        /// 电影(主分区)
        /// </summary>
        movie = 23,

        /// <summary>
        /// 华语电影	
        /// </summary>
        chinese_movie = 147,

        /// <summary>
        /// 欧美电影	
        /// </summary>
        west_movie = 145,

        /// <summary>
        /// 日本电影	
        /// </summary>
        japan = 146,

        /// <summary>
        /// 其他国家电影
        /// </summary>
        other_country_movie = 83,

        /// <summary>
        /// 电视剧(主分区)
        /// </summary>
        tv = 11,

        /// <summary>
        /// 国产剧	
        /// </summary>
        mainland = 185,

        /// <summary>
        /// 海外剧	
        /// </summary>
        overseas = 187
    }


}
