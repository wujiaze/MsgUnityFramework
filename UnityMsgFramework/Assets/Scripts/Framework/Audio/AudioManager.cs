/*	
 *	 Title : 基于消息机制的Unity框架
 * 		主题:声音模块管理
 *
 *		功能
 *
 *		日期 2018.6.22
*/
public class AudioManager : ManagerBase
{
    public static AudioManager Instance = null;

    private void Awake()
    {
        Instance = this;
    }

}
